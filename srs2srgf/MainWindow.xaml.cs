using Microsoft.Win32;
using srs2srgf.Models;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using srs2srgf.Tools;

namespace srs2srgf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static string inputFilePath = string.Empty;
        private static string outputPath = string.Empty;

        public MainWindow()
        {
            InitializeComponent();
            SetAppVersion();
        }

        private void SetAppVersion()
        {
            AppVersionText.Text += Application.Current.Resources["appVersion"];
        }

        private void SetInputFile(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.RestoreDirectory = true;
            openFileDialog.Filter = "JSON Files (*.json)|*.json";
            bool? result = openFileDialog.ShowDialog();
            if (result == true)
            {
                inputFilePath = openFileDialog.FileName;
                InputFileNameText.Text = openFileDialog.SafeFileName;
            }
        }

        private void SetOutputPath(object sender, RoutedEventArgs e)
        {
            OpenFolderDialog openFolderDialog = new OpenFolderDialog();
            openFolderDialog.Multiselect = false;
            bool? result = openFolderDialog.ShowDialog();
            if (result == true)
            {
                outputPath = openFolderDialog.FolderName;
                OutputFilePathText.Text = outputPath;
            }
        }

        private void StartConvert(object sender, RoutedEventArgs e)
        {
            if (inputFilePath == string.Empty || outputPath == string.Empty || GameUidForm.Text.Length <= 0)
            {
                MessageBoxResult messageBoxResult = MessageBox.Show("转换文件/导出路径/UID不能为空 :( ",
                    "失败",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
            else
            {
                ProcessingLog.Text = "正在从StarRailStation备份文件中提取原始格式的抽卡记录" + Environment.NewLine;
                List<SRSGachaItem> sRSGachaItems = SRSImport.ImportSRSGachaItems(inputFilePath);
                ProcessingLog.Text += "共提取到"+ sRSGachaItems.Count +"条记录" + Environment.NewLine;
                ProcessingLog.Text += "正在将StarRailStation的抽卡记录转化为SRGF记录格式" + Environment.NewLine;
                List<SRGFGachaItem> sRGFGachaItems = SRSImport.SRSGachaItemsToSRGFGachaItems(sRSGachaItems);
                ProcessingLog.Text += "正在生成SRGF导出信息" + Environment.NewLine;
                SRGFInfo sRGFInfo = SRGFExport.SetSRGFInfo(GameUidForm.Text);
                ProcessingLog.Text += "正在合并SRGF片段并导出SRGF到" + outputPath +Environment.NewLine;
                if (SRGFExport.ExportSRGFToPath(sRGFInfo, sRGFGachaItems, outputPath))
                {
                    ProcessingLog.Text += "转换完成 :) " + Environment.NewLine;
                }
                else
                {
                    MessageBoxResult messageBoxResult = MessageBox.Show("转换失败 :( ，请检查所需信息",
                    "失败",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
                }
            }
        }
    }
}