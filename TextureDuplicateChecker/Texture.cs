using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace TextureDuplicateChecker
{
	public class Texture
	{
		public string FilePath { get; set; }
		public string NeatFilePath { get; set; }
		public string FileName { get; set; }
		private string MD5 { get; set; }
		private string SHA256 { get; set; }

		public Color[,] Matrix { get; set; }

		public string GetMD5()
		{
			if (string.IsNullOrEmpty(MD5))
				MD5 = GetMD5HashFromFile(FilePath);

			return MD5;
		}

		public string GetSHA256()
		{
			if (string.IsNullOrEmpty(SHA256))
				SHA256 = GetSHA256HashFromFile(FilePath);

			return SHA256;
		}

		private string GetMD5HashFromFile(string fileName)
		{
			FileStream file = new FileStream(fileName, FileMode.Open);
			MD5 md5 = new MD5CryptoServiceProvider();
			byte[] retVal = md5.ComputeHash(file);
			file.Close();

			StringBuilder sb = new StringBuilder();
			for (int i = 0; i < retVal.Length; i++)
			{
				sb.Append(retVal[i].ToString("x2"));
			}
			return sb.ToString();
		}

		private string GetSHA256HashFromFile(string fileName)
		{
			FileStream file = new FileStream(fileName, FileMode.Open);
			SHA256 sha = new SHA256CryptoServiceProvider();
			byte[] retVal = sha.ComputeHash(file);
			file.Close();

			StringBuilder sb = new StringBuilder();
			for (int i = 0; i < retVal.Length; i++)
			{
				sb.Append(retVal[i].ToString("x2"));
			}
			return sb.ToString();
		}
	}

	public class TextureEqualityComparer : IEqualityComparer<Texture>
	{

		public bool Equals(Texture c1, Texture c2)
		{
			return (c1.GetMD5() == c2.GetMD5());
		}


		public int GetHashCode(Texture c)
		{
			return c.GetMD5().GetHashCode();
		}

	}
}
