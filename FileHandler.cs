using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
namespace BlackNotepad
{
    internal class FileHandler
    {
        public static string fileContent = string.Empty;
        public static string filePath = string.Empty;
        public static Encoding encoding = null;
        public static string filename = "Untitled";
        public static bool changed = false;

        public static string OpenFileText()
        {

            try
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.InitialDirectory = "c:\\";
                    openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                    openFileDialog.FilterIndex = 2;
                    openFileDialog.RestoreDirectory = true;

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        //Get the path of specified file
                        filePath = openFileDialog.FileName;
                        filename = Regex.Match(filePath, @".*\\([^\\]+$)").Groups[1].Value;

                        //Read the contents of the file into a stream
                        Stream fileStream = openFileDialog.OpenFile();

                        using (StreamReader reader = new StreamReader(fileStream))
                        {
                            fileContent = reader.ReadToEnd();
                            encoding = reader.CurrentEncoding;
                        }
                    }
                }
                return fileContent;

            }
            catch
            {
                MessageBox.Show("Error Opening the file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }


        }
        public static string OpenFileText(string Location)
        {
            try
            {


                //Read the contents of the file into a stream
                FileStream fileStream = new FileStream(Location, FileMode.Open);

                using (StreamReader reader = new StreamReader(fileStream))
                {
                    fileContent = reader.ReadToEnd();
                    encoding = reader.CurrentEncoding;
                }
                filename = Regex.Match(Location, @".*\\([^\\]+$)").Groups[1].Value;


                return fileContent;

            }
            catch
            {
                MessageBox.Show("Error Opening the file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }

        }
        public static void SaveFileText(string fileContent)
        {
            FileStream fs = null;
            if (filePath != string.Empty)

            {
                fs = new FileStream(filePath, FileMode.OpenOrCreate);
                if (encoding is null)
                {
                    encoding = Encoding.UTF8;
                }

                using (StreamWriter writer = new StreamWriter(fs, encoding))
                {
                    writer.Write(fileContent);
                    writer.Dispose();
                }
            }
            else
            {

                SaveFileDialog saveFileDialog1 = new SaveFileDialog
                {
                    Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*",
                    FilterIndex = 2,
                    RestoreDirectory = true
                };

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    if (encoding is null)
                    {
                        encoding = Encoding.UTF8;
                    }

                    fs = new FileStream(saveFileDialog1.FileName, FileMode.OpenOrCreate);
                    using (StreamWriter writer = new StreamWriter(fs, encoding))
                    {
                        writer.Write(fileContent);
                        writer.Dispose();
                    }

                }
            }

        }

        public static void NewFileText()
        {
            fileContent = string.Empty;
            filePath = string.Empty;
            filename = "Untitled";
            changed = false;
        }
    }
}
