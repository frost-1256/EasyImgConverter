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
                MessageBox.Show(fileName); // �C��: MessageBox.Show���g�p���ăt�@�C������\��  
                GetExtensionFromFullPath(fileName); // �C��: MessageBox.Show���g�p���ăt�@�C������\��

                string orgext = GetExtensionFromFullPath(fileName); // �C��: MessageBox.Show���g�p���ăt�@�C������\��
                MessageBox.Show(orgext); // �C��: MessageBox.Show���g�p���ăt�@�C������\��
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
                MessageBox.Show(fileName); // �C��: MessageBox.Show���g�p���ăt�@�C������\��  
                string orgext = GetExtensionFromFullPath(fileName); // �C��: MessageBox.Show���g�p���ăt�@�C������\��
                MessageBox.Show(orgext); // �C��: MessageBox.Show���g�p���ăt�@�C������\��
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
    }
}
