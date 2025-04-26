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
                MessageBox.Show(fileName); // 修正: MessageBox.Showを使用してファイル名を表示  
                GetExtensionFromFullPath(fileName); // 修正: MessageBox.Showを使用してファイル名を表示

                string orgext = GetExtensionFromFullPath(fileName); // 修正: MessageBox.Showを使用してファイル名を表示
                MessageBox.Show(orgext); // 修正: MessageBox.Showを使用してファイル名を表示
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
                MessageBox.Show(fileName); // 修正: MessageBox.Showを使用してファイル名を表示  
                string orgext = GetExtensionFromFullPath(fileName); // 修正: MessageBox.Showを使用してファイル名を表示
                MessageBox.Show(orgext); // 修正: MessageBox.Showを使用してファイル名を表示
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
