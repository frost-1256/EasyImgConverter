using System;
using System.Drawing;
using System.Drawing.Imaging; // ImageFormat.Icon を使うために必要
using System.Drawing.Drawing2D; // 縮小時の補間モード指定などに必要
using System.IO; // パス操作に必要

namespace WinFormsApp1;
/// <summary>
/// 画像ファイルに関する変換機能を提供する静的クラスです。
/// </summary>
public static class ImageConverter
{
    /// <summary>
    /// 指定された画像ファイルを読み込み、32x32ピクセルにリサイズしてICOファイルとして保存します。
    /// </summary>
    /// <param name="sourceImagePath">変換元の画像ファイルパス。</param>
    /// <param name="outputIconPath">保存先のICOファイルパス。</param>
    /// <exception cref="ArgumentNullException">sourceImagePath または outputIconPath が null または空の場合にスローされます。</exception>
    /// <exception cref="FileNotFoundException">変換元の画像ファイルが見つからない場合にスローされます。</exception>
    /// <exception cref="OutOfMemoryException">ファイルが有効な画像形式でないか、破損している場合にスローされることがあります。</exception>
    /// <exception cref="System.Runtime.InteropServices.ExternalException">GDI+ (System.Drawing の内部描画エンジン) 関連のエラーが発生した場合にスローされます。</exception>
    /// <exception cref="Exception">上記以外の予期しないエラーが発生した場合にスローされます。</exception>
    public static void Create32x32Icon(string sourceImagePath, string outputIconPath)
    {
        // 入力パスの基本的な検証
        if (string.IsNullOrEmpty(sourceImagePath))
        {
            throw new ArgumentNullException(nameof(sourceImagePath), "変換元の画像ファイルパスは null または空にできません。");
        }
        if (string.IsNullOrEmpty(outputIconPath))
        {
            throw new ArgumentNullException(nameof(outputIconPath), "保存先のICOファイルパスは null または空にできません。");
        }

        try
        {
            // 1. 元の画像を読み込む
            // using ステートメントでリソースの解放を保証
            using (Image originalImage = Image.FromFile(sourceImagePath))
            {
                // 2. 32x32 ピクセルの新しい Bitmap を作成 (リサイズ用)
                using (Bitmap resizedBitmap = new Bitmap(32, 32))
                {
                    // 3. 新しい Bitmap に描画するための Graphics オブジェクトを作成
                    using (Graphics g = Graphics.FromImage(resizedBitmap))
                    {
                        // 描画品質の設定 (縮小結果の向上)
                        g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        g.SmoothingMode = SmoothingMode.HighQuality;
                        g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                        g.CompositingQuality = CompositingQuality.HighQuality;

                        // 4. 元の画像を新しい Bitmap に描画 (32x32にスケーリング)
                        g.DrawImage(originalImage, 0, 0, 32, 32);

                    } // Graphics オブジェクトは自動的に破棄されます

                    // 5. 縮小された Bitmap を ICO 形式で保存
                    // System.DrawingでのICO保存は、元の画像や環境により制限がある場合があります。
                    resizedBitmap.Save(outputIconPath, ImageFormat.Icon);

                    Console.WriteLine($"成功: {sourceImagePath} を 32x32 の ICO ファイルとして {outputIconPath} に保存しました。");
                } // resizedBitmap オブジェクトは自動的に破棄されます
            } // originalImage オブジェクトは自動的に破棄されます
        }
        catch (FileNotFoundException ex)
        {
            // エラーをコンソール出力し、呼び出し元に再スロー
            Console.Error.WriteLine($"エラー: 指定されたファイルが見つかりません: {sourceImagePath}. {ex.Message}");
            throw; // 例外を再スロー
        }
        catch (OutOfMemoryException ex)
        {
            Console.Error.WriteLine($"エラー: {sourceImagePath} を画像として読み込めませんでした。ファイルが有効な画像形式でないか、破損している可能性があります。 {ex.Message}");
            throw; // 例外を再スロー
        }
        catch (System.Runtime.InteropServices.ExternalException ex)
        {
            Console.Error.WriteLine($"GDI+ エラーが発生しました (画像処理中または保存時): {ex.Message}");
            Console.Error.WriteLine("ヒント: System.DrawingでのICO保存は、元の画像や環境により制限がある場合があります。");
            throw; // 例外を再スロー
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"予期しないエラーが発生しました: {ex.Message}");
            throw; // 例外を再スロー
        }
    }
}