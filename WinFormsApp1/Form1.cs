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
            //�t�@�C���̊g���q���擾
            return System.IO.Path.GetExtension(file);
        }

        private void panel1_DragDrop(object sender, DragEventArgs e)
        {
            // DataFormats.FileDrop��^���āAGetDataPresent()���\�b�h���Ăяo���B  
            var files = (string[])e.Data.GetData(DataFormats.FileDrop, false);

            // GetData�̖߂�l��string�^�̔z��ł���A  
            // �����̃t�@�C�����h���b�v���ꂽ�ꍇ�ɂ�  
            // �h���b�v���ꂽ�����̃t�@�C�������擾�ł���B  

            for (int i = 0; i < files.Length; i++)
            {
                // GetData�ɂ��擾����String�^�̔z�񂩂�v�f�����o���B  
                var fileName = files[i];
                Console.Write(fileName);
                // MessageBox.Show(fileName); // �C��: MessageBox.Show���g�p���ăt�@�C������\��  
                GetExtensionFromFullPath(fileName); // �C��: MessageBox.Show���g�p���ăt�@�C������\��

                string orgext = GetExtensionFromFullPath(fileName); // �C��: MessageBox.Show���g�p���ăt�@�C������\��
                                                                    // MessageBox.Show(orgext); // �C��: MessageBox.Show���g�p���ăt�@�C������\��
                                                                    //System.Drawing.Image img = System.Drawing.Image.FromFile(fileName); // �C��: MessageBox.Show���g�p���ăt�@�C������\��
                System.Drawing.Image img = System.Drawing.Image.FromFile(fileName);


                System.Drawing.Image orgimg = System.Drawing.Image.FromFile(fileName);
                try
                {
                    // �摜��ϊ�����t�H�[�}�b�g���擾
                    string targetFormat = comboBox1.SelectedItem.ToString();

                    // �ۑ���̃t�@�C���p�X�𐶐�
                    string newFileName = System.IO.Path.ChangeExtension(fileName, targetFormat.ToLower());

                    // �摜���w�肳�ꂽ�t�H�[�}�b�g�ŕۑ�
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
                            MessageBox.Show("�Ή����Ă��Ȃ��t�H�[�}�b�g�ł�: " + targetFormat);
                            return;
                    }

                    // MessageBox.Show($"�ϊ����������܂���: {newFileName}");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"�G���[���������܂���: {ex.Message}");
                }
                // �ϊ����������s����
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
            // DataFormats.FileDrop��^���āAGetDataPresent()���\�b�h���Ăяo���B  
            var files = (string[])e.Data.GetData(DataFormats.FileDrop, false);

            // GetData�̖߂�l��string�^�̔z��ł���A  
            // �����̃t�@�C�����h���b�v���ꂽ�ꍇ�ɂ�  
            // �h���b�v���ꂽ�����̃t�@�C�������擾�ł���B  

            for (int i = 0; i < files.Length; i++)
            {
                // GetData�ɂ��擾����String�^�̔z�񂩂�v�f�����o���B  
                var fileName = files[i];
                Console.Write(fileName);
                //MessageBox.Show(fileName); // �C��: MessageBox.Show���g�p���ăt�@�C������\��  
                string orgext = GetExtensionFromFullPath(fileName); // �C��: MessageBox.Show���g�p���ăt�@�C������\��
                //MessageBox.Show(orgext); // �C��: MessageBox.Show���g�p���ăt�@�C������\��

                // System.Drawing.Image img = System.Drawing.Image.FromFile(fileName); // �C��: MessageBox.Show���g�p���ăt�@�C������\��
                System.Drawing.Image img = System.Drawing.Image.FromFile(fileName);
                // �ϊ����������s����
                try
                {
                    // �摜��ϊ�����t�H�[�}�b�g���擾
                    string targetFormat = comboBox2.SelectedItem.ToString();

                    // �ۑ���̃t�@�C���p�X�𐶐�
                    string newFileName = System.IO.Path.ChangeExtension(fileName, targetFormat.ToLower());

                    // �摜���w�肳�ꂽ�t�H�[�}�b�g�ŕۑ�
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
                            // MessageBox.Show("�Ή����Ă��Ȃ��t�H�[�}�b�g�ł�: " + targetFormat);
                            return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"�G���[���������܂���: {ex.Message}");
                }
                // �ϊ����������s����
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
