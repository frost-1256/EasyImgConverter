namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedItem = "PNG"; // comboBox Default value  
            comboBox2.SelectedItem = "ICO"; // comboBox Default value  
            this.TopMost = Properties.Settings.Default.istop;
            checkBox1.Checked = Properties.Settings.Default.istop;
        }
        private string GetExtensionFromFullPath(string file)
        {
            //ファイルの拡張子を取得
            return System.IO.Path.GetExtension(file);
        }

        private void panel1_DragDrop(object sender, DragEventArgs e)
        {
            // DataFormats.FileDropを与えて、GetDataPresent()メソッドを呼び出す。  
            var files = (string[])e.Data.GetData(DataFormats.FileDrop, false);

            // GetDataの戻り値はstring型の配列であり、  
            // 複数のファイルがドロップされた場合には  
            // ドロップされた複数のファイル名が取得できる。  

            for (int i = 0; i < files.Length; i++)
            {
                // GetDataにより取得したString型の配列から要素を取り出す。  
                var fileName = files[i];
                Console.Write(fileName);
                // MessageBox.Show(fileName); // 修正: MessageBox.Showを使用してファイル名を表示  
                GetExtensionFromFullPath(fileName); // 修正: MessageBox.Showを使用してファイル名を表示

                string orgext = GetExtensionFromFullPath(fileName); // 修正: MessageBox.Showを使用してファイル名を表示
                                                                    // MessageBox.Show(orgext); // 修正: MessageBox.Showを使用してファイル名を表示
                                                                    //System.Drawing.Image img = System.Drawing.Image.FromFile(fileName); // 修正: MessageBox.Showを使用してファイル名を表示
                System.Drawing.Image img = System.Drawing.Image.FromFile(fileName);


                System.Drawing.Image orgimg = System.Drawing.Image.FromFile(fileName);
                try
                {
                    // 画像を変換するフォーマットを取得
                    string targetFormat = comboBox1.SelectedItem.ToString();

                    // 保存先のファイルパスを生成
                    string newFileName = System.IO.Path.ChangeExtension(fileName, targetFormat.ToLower());

                    // 画像を指定されたフォーマットで保存
                    switch (targetFormat)
                    {
                        case "PNG":
                            img.Save(newFileName, System.Drawing.Imaging.ImageFormat.Png);
                            img.Dispose();
                            break;
                        case "ICO":
                            img.Save(newFileName, System.Drawing.Imaging.ImageFormat.Icon);
                            img.Dispose();
                            break;
                        case "JPEG":
                        case "JPG":
                            img.Save(newFileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                            img.Dispose();
                            break;
                        case "BMP":
                            img.Save(newFileName, System.Drawing.Imaging.ImageFormat.Bmp);
                            img.Dispose();
                            break;
                        case "WebP":
                            img.Save(newFileName, System.Drawing.Imaging.ImageFormat.Webp);
                            img.Dispose();
                            break;
                        default:
                            MessageBox.Show("対応していないフォーマットです: " + targetFormat);
                            return;
                    }

                    // MessageBox.Show($"変換が完了しました: {newFileName}");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"エラーが発生しました: {ex.Message}");
                }
                // 変換処理を実行する
            }
        }

        private void panel1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void panel2_DragDrop(object sender, DragEventArgs e)
        {
            // DataFormats.FileDropを与えて、GetDataPresent()メソッドを呼び出す。  
            var files = (string[])e.Data.GetData(DataFormats.FileDrop, false);

            // GetDataの戻り値はstring型の配列であり、  
            // 複数のファイルがドロップされた場合には  
            // ドロップされた複数のファイル名が取得できる。  

            for (int i = 0; i < files.Length; i++)
            {
                // GetDataにより取得したString型の配列から要素を取り出す。  
                var fileName = files[i];
                Console.Write(fileName);
                //MessageBox.Show(fileName); // 修正: MessageBox.Showを使用してファイル名を表示  
                string orgext = GetExtensionFromFullPath(fileName); // 修正: MessageBox.Showを使用してファイル名を表示
                //MessageBox.Show(orgext); // 修正: MessageBox.Showを使用してファイル名を表示

                // System.Drawing.Image img = System.Drawing.Image.FromFile(fileName); // 修正: MessageBox.Showを使用してファイル名を表示
                System.Drawing.Image img = System.Drawing.Image.FromFile(fileName);
                // 変換処理を実行する
                try
                {
                    // 画像を変換するフォーマットを取得
                    string targetFormat = comboBox2.SelectedItem.ToString();

                    // 保存先のファイルパスを生成
                    string newFileName = System.IO.Path.ChangeExtension(fileName, targetFormat.ToLower());

                    // 画像を指定されたフォーマットで保存
                    switch (targetFormat)
                    {
                        case "PNG":
                            img.Save(newFileName, System.Drawing.Imaging.ImageFormat.Png);
                            img.Dispose();
                            break;
                        case "ICO":
                            img.Save(newFileName, System.Drawing.Imaging.ImageFormat.Icon);
                            img.Dispose();
                            break;
                        case "JPEG":
                        case "JPG":
                            img.Save(newFileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                            img.Dispose();
                            break;
                        case "BMP":
                            img.Save(newFileName, System.Drawing.Imaging.ImageFormat.Bmp);
                            img.Dispose();
                            break;
                        case "WebP":
                            img.Save(newFileName, System.Drawing.Imaging.ImageFormat.Webp);
                            img.Dispose();
                            break;
                        default:
                            // MessageBox.Show("対応していないフォーマットです: " + targetFormat);
                            return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"エラーが発生しました: {ex.Message}");
                }
                // 変換処理を実行する
            }
        }

        private void panel2_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                Properties.Settings.Default.istop = true;
                Properties.Settings.Default.Save();
                this.TopMost = true;
            }
            else
            {
                this.TopMost = Properties.Settings.Default.istop = false;
                Properties.Settings.Default.Save();
                this.TopMost = false;
            }
        }
    }
}
