using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextureDuplicateChecker
{
	public partial class UI : Form
	{
		private readonly Stopwatch _perfTimer = new Stopwatch();
		private bool _complexModeRanLast; // Not ideal, but works for now

		public UI()
		{
			InitializeComponent();
		}

		private List<Texture> GetFileListFromPack(string packPath, string packName)
		{
			_perfTimer.Restart();
			string[] allFiles = Directory.GetFiles(packPath, "*.png", SearchOption.AllDirectories);
			List<Texture> allTextures = new List<Texture>();

			foreach (string file in allFiles)
			{
				if (!string.IsNullOrEmpty(file))
				{
					allTextures.Add(new Texture()
					{
						FilePath = file,
						NeatFilePath = Path.Combine(packName, file.Replace(packPath, "").Trim('/', '\\')),
						FileName = file.Split('\\', '/').Last()
					});
				}
			}

			_perfTimer.Stop();
			BeginInvoke(new Action(() =>
			{
				perfTimeLog.AppendText($"Gathered all textures for {packName} in {_perfTimer.ElapsedMilliseconds}ms!\n");
			}));
			return allTextures;
		}

		private void GetDuplicateTextures(string packPath1, string packPath2, string pack1Name = "Pack One", string pack2Name = "Pack Two")
		{
			packOneNameTextbox.Text = pack1Name;
			packTwoNameTextbox.Text = pack2Name;

			if (!ValidatePackPath(packPath1))
			{
				outputTextBox.AppendText($"Invalid pack ({packPath1})\n");

				searchButton.Enabled = true;
				exportButton.Enabled = false;
				packOneNameTextbox.Enabled = true;
				packTwoNameTextbox.Enabled = true;
				optionsGroup.Enabled = true;
				advancedGroup.Enabled = true;

				return;
			}
			if (!ValidatePackPath(packPath2))
			{
				outputTextBox.AppendText($"Invalid pack ({packPath2})\n");

				searchButton.Enabled = true;
				exportButton.Enabled = false;
				packOneNameTextbox.Enabled = true;
				packTwoNameTextbox.Enabled = true;
				optionsGroup.Enabled = true;
				advancedGroup.Enabled = true;

				return;
			}

			_perfTimer.Restart();
			List<Texture> packOne = new List<Texture>();
			List<Texture> packTwo = new List<Texture>();

			Task packOneTask = new Task(() =>
			{
				packOne = GetFileListFromPack(packPath1, pack1Name);

				foreach (Texture texture in packOne)
				{
					texture.GetMD5();
				}
			});

			Task packTwoTask = new Task(() =>
			{
				packTwo = GetFileListFromPack(packPath2, pack2Name);

				foreach (Texture texture in packTwo)
				{
					texture.GetMD5();
				}
			});

			packOneTask.Start();
			packTwoTask.Start();

			while(!packOneTask.IsCompleted || !packTwoTask.IsCompleted)
				Thread.Sleep(100);

			_perfTimer.Stop();
			BeginInvoke(new Action(() =>
			{
				perfTimeLog.AppendText($"Calculated duplicate textures in {_perfTimer.ElapsedMilliseconds}ms!\n");
			}));

			SmartPrintDuplicate(packOne, packTwo);

			searchButton.Enabled = true;
			exportButton.Enabled = true;
			resetButton.Enabled = true;
			packOneNameTextbox.Enabled = true;
			packTwoNameTextbox.Enabled = true;
			optionsGroup.Enabled = true;
			advancedGroup.Enabled = true;
		}

		private void SmartPrintDuplicate(List<Texture> packOne, List<Texture> packTwo)
		{
			duplicateCount.Text = "0";
			Task printingTask = new Task(() =>
			{
				_perfTimer.Restart();

				foreach (Texture p1Tex in packOne)
				{
					try
					{
						Texture p2Tex = packTwo.First(p => p.GetMD5() == p1Tex.GetMD5());
						if ((fileNameLimit.Checked ? p1Tex.FileName == p2Tex.FileName : true) && p1Tex.GetSHA256() == p2Tex.GetSHA256())
						{
							this.BeginInvoke(new Action(() =>
							{
								outputTextBox.AppendText($"Duplicate {Convert.ToInt32(duplicateCount.Text) + 1}{(fileNameLimit.Checked ? $" ({p1Tex.FileName})" : "")}:\n1: {(neatFilePaths.Checked ? p1Tex.NeatFilePath : p1Tex.FilePath)}\n2: {(neatFilePaths.Checked ? p2Tex.NeatFilePath : p2Tex.FilePath)}\nSHA256: {p1Tex.GetSHA256()}\n\n");
								duplicateCount.Text = $"{Convert.ToInt32(duplicateCount.Text) + 1}";
							}));
						}
					}
					catch { } // Lazy solution
				}

				_perfTimer.Stop();
				this.BeginInvoke(new Action(() =>
				{
					perfTimeLog.AppendText($"Compared all textures within {_perfTimer.ElapsedMilliseconds}ms!\n");
				}));
			});
			printingTask.Start();
		}

		private bool ValidatePackPath(string packPath)
		{
			return !validatePack.Checked || File.Exists(Path.Combine(packPath, "pack.mcmeta"));
		}

		private void searchButton_Click(object sender, EventArgs e)
		{
			searchButton.Enabled = false;
			resetButton.Enabled = false;
			packOneNameTextbox.Enabled = false;
			packTwoNameTextbox.Enabled = false;
			optionsGroup.Enabled = false;
			advancedGroup.Enabled = false;
			outputTextBox.Clear();
			perfTimeLog.Clear();

			if (!complexCheck.Checked)
			{
				_complexModeRanLast = false;
				GetDuplicateTextures(packOnePath.Text, packTwoPath.Text, packOneNameTextbox.Text, packTwoNameTextbox.Text);
			}
			else
			{
				_complexModeRanLast = true;
				GetComplexTextures(packOnePath.Text, packTwoPath.Text, packOneNameTextbox.Text, packTwoNameTextbox.Text);
			}
		}

		private void resetButton_Click(object sender, EventArgs e)
		{
			searchButton.Enabled = true;
			exportButton.Enabled = false;
			packOneNameTextbox.Enabled = true;
			packTwoNameTextbox.Enabled = true;
			optionsGroup.Enabled = true;
			advancedGroup.Enabled = true;
			outputTextBox.Clear();
			perfTimeLog.Clear();
		}

		private void exportButton_Click(object sender, EventArgs e)
		{
			// Not great.
			if (!_complexModeRanLast)
				File.WriteAllText($"DuplicateTextures-{packOneNameTextbox.Text.Replace(" ", "_")}-{packTwoNameTextbox.Text.Replace(" ", "_")}.txt", $"WARNING! This tool should not be used for evidence alone.\nPlease verify the hashes of the duplicate files manually using a trusted tool to double check the results!\n\nPack 1: {packOneNameTextbox.Text}\nPack 2: {packTwoNameTextbox.Text}\nDuplicate Textures: {duplicateCount.Text}\n\n{outputTextBox.Text}");
			else
				File.WriteAllText($"SimilarTextures-{packOneNameTextbox.Text.Replace(" ", "_")}-{packTwoNameTextbox.Text.Replace(" ", "_")}.txt", $"WARNING! This tool should not be used for evidence alone.\nPlease verify the files are actually similar manually! An automated tool can easily give false positives!\n\nPack 1: {packOneNameTextbox.Text}\nPack 2: {packTwoNameTextbox.Text}\nSimilar Textures: {duplicateCount.Text}\n\n{outputTextBox.Text}");
		}

		private void packPath_TextChanged(object sender, EventArgs e)
		{
			if (!string.IsNullOrWhiteSpace(packOnePath.Text) && !string.IsNullOrWhiteSpace(packTwoPath.Text))
				searchButton.Enabled = true;
			else
				searchButton.Enabled = false;
		}

		#region Complex Check
		// This adds a lot of duplicated code. This needs refactoring...
		private void GetComplexTextures(string packPath1, string packPath2, string pack1Name = "Pack One", string pack2Name = "Pack Two")
		{
			packOneNameTextbox.Text = pack1Name;
			packTwoNameTextbox.Text = pack2Name;

			if (!ValidatePackPath(packPath1))
			{
				outputTextBox.AppendText($"Invalid pack ({packPath1})\n");

				searchButton.Enabled = true;
				exportButton.Enabled = false;
				packOneNameTextbox.Enabled = true;
				packTwoNameTextbox.Enabled = true;
				optionsGroup.Enabled = true;
				advancedGroup.Enabled = true;

				return;
			}
			if (!ValidatePackPath(packPath2))
			{
				outputTextBox.AppendText($"Invalid pack ({packPath2})\n");

				searchButton.Enabled = true;
				exportButton.Enabled = false;
				packOneNameTextbox.Enabled = true;
				packTwoNameTextbox.Enabled = true;
				optionsGroup.Enabled = true;
				advancedGroup.Enabled = true;

				return;
			}

			_perfTimer.Restart();
			List<Texture> packOne = new List<Texture>();
			List<Texture> packTwo = new List<Texture>();

			Task packOneTask = new Task(() =>
			{
				packOne = GetFileListFromPack(packPath1, pack1Name);

				foreach (Texture texture in packOne)
					texture.Matrix = GetBitmapColorMatrix(texture.FilePath);
			});

			Task packTwoTask = new Task(() =>
			{
				packTwo = GetFileListFromPack(packPath2, pack2Name);

				foreach (Texture texture in packTwo)
					texture.Matrix = GetBitmapColorMatrix(texture.FilePath);
			});

			packOneTask.Start();
			packTwoTask.Start();

			while (!packOneTask.IsCompleted || !packTwoTask.IsCompleted)
				Thread.Sleep(100);

			_perfTimer.Stop();
			BeginInvoke(new Action(() =>
			{
				perfTimeLog.AppendText($"Calculated texture matrices in {_perfTimer.ElapsedMilliseconds}ms!\n");
			}));

			SmartPrintMatricesSimilar(packOne, packTwo);

			searchButton.Enabled = true;
			exportButton.Enabled = true;
			resetButton.Enabled = true;
			packOneNameTextbox.Enabled = true;
			packTwoNameTextbox.Enabled = true;
			optionsGroup.Enabled = true;
			advancedGroup.Enabled = true;
		}

		private Color[,] GetBitmapColorMatrix(string filePath)
		{
			Bitmap bmp = new Bitmap(filePath);
			int height = bmp.Height;
			int width = bmp.Width;
			Color[,] matrix = new Color[width, height];

			for (int x = 0; x < width; x++)
			{
				for (int y = 0; y < height; y++)
				{
					matrix[x, y] = bmp.GetPixel(x, y);
				}
			}
			return matrix;
		}

		private void SmartPrintMatricesSimilar(List<Texture> packOne, List<Texture> packTwo)
		{
			duplicateCount.Text = "0";
			float minPercent = (float)percentInput.Value / 100;
			Task printingTask = new Task(() =>
			{
				_perfTimer.Restart();

				foreach (Texture p1Tex in packOne)
				{
					foreach (Texture p2Tex in packTwo)
					{
						float textureMatchingPercent;
						if (IsMatrixSimilar(p1Tex.Matrix, p2Tex.Matrix, out textureMatchingPercent, minPercent))
						{
							BeginInvoke(new Action(() =>
							{
								outputTextBox.AppendText($"Similar texture {Convert.ToInt32(duplicateCount.Text) + 1}{(fileNameLimit.Checked ? $" ({p1Tex.FileName})" : "")} ({Math.Round((textureMatchingPercent * 100), 2)}%):\n1: {(neatFilePaths.Checked ? p1Tex.NeatFilePath : p1Tex.FilePath)}\n2: {(neatFilePaths.Checked ? p2Tex.NeatFilePath : p2Tex.FilePath)}\n\n");
								duplicateCount.Text = $"{Convert.ToInt32(duplicateCount.Text) + 1}";
							}));
						}
					}
				}

				_perfTimer.Stop();
				BeginInvoke(new Action(() =>
				{
					perfTimeLog.AppendText($"Compared all texture matrices within {_perfTimer.ElapsedMilliseconds}ms!\n");
				}));
			});
			printingTask.Start();
		}

		private bool IsMatrixSimilar(Color[,] matrixOne, Color[,] matrixTwo, out float textureMatchingPercent, float minPercent = 0.9f)
		{
			int matchingPixels = 0;
			int totalPixels = 0;

			if (matrixOne.GetLength(0) != matrixTwo.GetLength(0) || matrixOne.GetLength(1) != matrixTwo.GetLength(1))
			{
				Console.WriteLine("Different matrix size detected! This is not supported at the moment!");
				textureMatchingPercent = 0;
				return false;
			}

			for (int x = 0; x < matrixOne.GetLength(0); x++)
			{
				for (int y = 0; y < matrixOne.GetLength(1); y++)
				{
					var col1 = matrixOne[x, y];
					var col2 = matrixTwo[x, y];

					// Ignore transparent pixels
					if (col1.A != 0 || col2.A != 0)
					{
						totalPixels++;
						if (col1 == col2)
							matchingPixels++;
					}
				}
			}

			textureMatchingPercent = (float)matchingPixels / (float)totalPixels;

			// Hide 100% matches if desired
			if (hideFullMatches.Checked && Math.Abs(textureMatchingPercent - 1.0f) < 0.001f)
				return false;
			return textureMatchingPercent >= minPercent;
		}
		#endregion
	}
}
