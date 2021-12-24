using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextureDuplicateChecker
{
    public partial class UI : Form
    {
        Stopwatch perfTimer = new Stopwatch();

        public UI()
        {
            InitializeComponent();
        }

        private List<Texture> GetFileListFromPack(string packPath, string packName)
        {
            perfTimer.Restart();
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

            perfTimer.Stop();
            this.BeginInvoke(new Action(() =>
            {
                perfTimeLog.AppendText($"Gathered all textures for {packName} in {perfTimer.ElapsedMilliseconds}ms!\n");
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
                return;
            }
            if (!ValidatePackPath(packPath2))
            {
                outputTextBox.AppendText($"Invalid pack ({packPath2})\n");
                return;
            }

            perfTimer.Restart();
            List<Texture> packOne = new List<Texture>();
            List<Texture> packTwo = new List<Texture>();

            Task packOneTask = new Task(() =>
            {
                packOne = GetFileListFromPack(packPath1, pack1Name);

                foreach (Texture texture in packOne)
                    texture.GetMD5();
            });

            Task packTwoTask = new Task(() =>
            {
                packTwo = GetFileListFromPack(packPath2, pack2Name);

                foreach (Texture texture in packTwo)
                    texture.GetMD5();
            });

            packOneTask.Start();
            packTwoTask.Start();

            while(!packOneTask.IsCompleted || !packTwoTask.IsCompleted)
                Thread.Sleep(100);

            perfTimer.Stop();
            this.BeginInvoke(new Action(() =>
            {
                perfTimeLog.AppendText($"Calculated duplicate textures in {perfTimer.ElapsedMilliseconds}ms!\n");
            }));

            SmartPrintDuplicate(packOne, packTwo);

            searchButton.Enabled = true;
            exportButton.Enabled = true;
            resetButton.Enabled = true;
            packOneNameTextbox.Enabled = true;
            packTwoNameTextbox.Enabled = true;
        }

        private void SmartPrintDuplicate(List<Texture> packOne, List<Texture> packTwo)
        {
            duplicateCount.Text = "0";
            Task printingTask = new Task(() =>
            {
                perfTimer.Restart();
                
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

                perfTimer.Stop();
                this.BeginInvoke(new Action(() =>
                {
                    perfTimeLog.AppendText($"Compared all textures within {perfTimer.ElapsedMilliseconds}ms!\n");
                }));
            });
            printingTask.Start();
        }

        private bool ValidatePackPath(string packPath)
        {
            return File.Exists(Path.Combine(packPath, "pack.mcmeta"));
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            searchButton.Enabled = false;
            resetButton.Enabled = false;
            packOneNameTextbox.Enabled = false;
            packTwoNameTextbox.Enabled = false;
            outputTextBox.Clear();
            perfTimeLog.Clear();
            GetDuplicateTextures(packOnePath.Text, packTwoPath.Text, packOneNameTextbox.Text, packTwoNameTextbox.Text);
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            searchButton.Enabled = true;
            exportButton.Enabled = false;
            packOneNameTextbox.Enabled = true;
            packTwoNameTextbox.Enabled = true;
            outputTextBox.Clear();
            perfTimeLog.Clear();
        }

        private void exportButton_Click(object sender, EventArgs e)
        {
            File.WriteAllText($"DuplicateTextures-{packOneNameTextbox.Text.Replace(" ", "_")}-{packTwoNameTextbox.Text.Replace(" ", "_")}.txt", $"WARNING! This tool should not be used for evidence alone.\nPlease verify the hashes of the duplicate files manually using a trusted tool to double check the results!\n\nPack 1: {packOneNameTextbox.Text}\nPack 2: {packTwoNameTextbox.Text}\nDuplicate Textures: {duplicateCount.Text}\n\n{outputTextBox.Text}");
        }

        private void packPath_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(packOnePath.Text) && !string.IsNullOrWhiteSpace(packTwoPath.Text))
                searchButton.Enabled = true;
            else
                searchButton.Enabled = false;
        }
    }
}
