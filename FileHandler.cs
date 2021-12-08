using System.IO;
using System.Text;
using System.Windows.Forms;
namespace BlackNotepad
{
    internal class FileHandler
    {
        private static string fileContent = string.Empty;
        private static string filePath = string.Empty;
        private static Encoding encoding = null;

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

                        //Read the contents of the file into a stream
                        var fileStream = openFileDialog.OpenFile();

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
                    encoding = Encoding.UTF8;

                using (StreamWriter writer = new StreamWriter(fs, encoding))
                {
                    writer.Write(fileContent);
                    writer.Dispose();
                }
            }
            else
            {
               
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();

                saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                saveFileDialog1.FilterIndex = 2;
                saveFileDialog1.RestoreDirectory = true;

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    if (encoding is null)
                        encoding = Encoding.UTF8;
                    fs = new FileStream(saveFileDialog1.FileName, FileMode.OpenOrCreate);
                    using (StreamWriter writer = new StreamWriter(fs, encoding))
                    {
                        writer.Write(fileContent);
                        writer.Dispose();
                    }

                }
            }

        }
    }
}
