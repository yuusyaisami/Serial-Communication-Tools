/* セーブデータシステム
 * 作成者  : Yuisami
 * 目的    : セーブ機能を簡単に搭載する
 * めも    : 暗号化はされていない
 * version : v1.1.0 
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SaveSystem
{
    //DataStorageクラスはname と dataを紐づけて、テキストファイルに保存するクラス、
    public static class DataStorage
    {
        public static string[] save_data = new string[2048];
        public static string[] save_name = new string[2048];
        /* ReadLineは名前が一致する行を探し、一致した行のデータをstringでreturnする
         */
        /// <summary>
        /// テキストファイル内の保存データを名前で呼び出す
        /// </summary>
        /// <param name="file_path">ファイルパスを入力</param>
        /// <param name="file_name">データの名前を入力</param>
        /// <returns>data</returns>
        public static string ReadLine(string file_path, string file_name)
        {
            if (File.Exists(file_path) == false)
            {
                using (FileStream fs = File.Create(file_path)) ;//ファイルがなかったら、新しく作る
            }
            StreamReader sr = new StreamReader(file_path, Encoding.GetEncoding("UTF-8")); //UTF-8でのテキストファイルを開く
            while (sr.Peek() != -1) //最後の行まで、繰り返す
            {
                int save_data_count; //読み取ったlineのindexを保存する
                string str = null;
                string read_data = sr.ReadLine(); //読み取ったデータ(line)
                for (save_data_count = 0; save_data_count < read_data.Length; save_data_count++)
                {
                    if (read_data[save_data_count].ToString() == "：" || read_data == null || read_data == "") //エスケープ条件文
                    {
                        break;
                    }
                    str += read_data[save_data_count].ToString(); //名前のみstrに保存する
                }
                if (str == file_name)
                {
                    str = null;
                    for (int i = save_data_count + 1; i < read_data.Length; i++)
                    {
                        str += read_data[i].ToString();
                    }
                    sr.Close();
                    return str; //名前が一致したら、その中のデータをreturnする
                }
            }
            sr.Close();
            return null;
        }
        /*テキストファイル内の名前とその名前を紐づけたデータを配列に保存し、書き換えたいデータを配列を書き換え、その配列を再度、フォーマットしたテキストファイルに保存する
         */
        /// <summary>
        /// テキストファイルにデータを保存する
        /// </summary>
        /// <param name="file_path">ファイルパス</param>
        /// <param name="file_name">データ名</param>
        /// <param name="data">データ</param>
        public static void WriteLine(string file_path, string file_name, string data)
        {
            if (File.Exists(file_path) == false)
            {
                using (FileStream fs = File.Create(file_path)) ;//ファイルがなかったら、新しく作る
            }
            for (int i = 0; i < save_name.Length; i++)
            {
                save_name[i] = save_data[i] = null; //初期化
            }
            StreamReader sr = new StreamReader(file_path, Encoding.GetEncoding("UTF-8"));
            int read_line_count = 0, save_index = -1; // 行のカウント / 保存したい行のindex
            while (sr.Peek() != -1)
            {
                string line = sr.ReadLine(); //読み取ったデータ
                bool name_flag = true, data_flag = false; //名前を保存するフラッグ / データを保存するフラッグ
                for (int i = 0; i < line.Length; i++)
                {
                    if (line[i].ToString() == "：")
                    {
                        name_flag = false;
                        data_flag = true;
                        i++; //"："を保存しないようにするため
                        if (i == line.Length)
                        {
                            break;//データがなかったら抜ける
                        }
                    }
                    if (name_flag)
                    {
                        save_name[read_line_count] += line[i].ToString();
                    }
                    else if (data_flag)
                    {
                        save_data[read_line_count] += line[i].ToString();
                    }
                }
                if (save_name[read_line_count] == file_name)
                {
                    save_index = read_line_count; //保存したい場所が見つかったので、save_indexにその時のindexを入れる
                }
                read_line_count++;
            }
            sr.Close();
            if (save_index == -1) //名前が見つからなかったら
            {
                for (int i = 0; ; i++)
                {
                    if (save_name[i] == null)
                    {
                        save_index = i; //一番後ろに保存する
                        break;
                    }
                }
            }
            save_name[save_index] = file_name;
            save_data[save_index] = data; //新しく書き入れるデータを入れる
            WriteTextFile(file_path);//保存
        }
        /// <summary>
        /// 指定されたデータと名前を削除する
        /// </summary>
        /// <param name="file_path"></param>
        /// <param name="data_name"></param>
        public static void DeleteLine(string file_path, string data_name)
        {
            string name = data_name, data = ""; int index = 0;
            SearchName_DataAndIndex(file_path , name, ref data, ref index); //名前と一致するデータとその時のインデックスを参照する
            for (int i = index; i < save_name.Length - 1; i++)
            {
                save_name[i] = save_name[i + 1]; //deleteするlineをleftにshiftする
                save_data[i] = save_data[i + 1]; //  削除する行を左にずらす
            }
            WriteTextFile(file_path);//save_nameとsave_dataをテキストファイルに保存する
        }
        /// <summary>
        /// すべてのデータと名前を削除する
        /// </summary>
        /// <param name="file_path"></param>
        public static void ClearLine(string file_path)
        {
            if (File.Exists(file_path))
            {
                File.Delete(file_path); //ファイルの中身を消すために一度削除する
                File.Create(file_path).Close(); //再び作成
            }
        }
        private static void WriteTextFile(string file_path)
        {
            File.Delete(file_path); //ファイルの中身を消すために一度削除する
            File.Create(file_path).Close(); //再び作成

            StreamWriter sw = new StreamWriter(file_path);
            for (int i = 0; save_name[i] != null; i++)
            {
                sw.Write(save_name[i] + "：" + save_data[i] + "\n"); //データを書き込む
            }
            sw.Close(); // StreamWriter を閉じる
        }
        private static void SearchName_DataAndIndex(string file_path,string data_name, ref string data, ref int index)
        {
            for (int i = 0; i < save_name.Length; i++)
            {
                save_name[i] = save_data[i] = null; //初期化
            }
            StreamReader sr = new StreamReader(file_path, Encoding.GetEncoding("UTF-8"));
            int read_line_count = 0; // 行のカウント
            int return_index = -1; //返す数値
            while (sr.Peek() != -1)
            {
                string line = sr.ReadLine(); //読み取ったデータ
                bool name_flag = true, data_flag = false; //名前を保存するフラッグ / データを保存するフラッグ
                for (int i = 0; i < line.Length; i++)
                {
                    if (line[i].ToString() == "：")
                    {
                        name_flag = false;
                        data_flag = true;
                        i++; //"："を保存しないようにするため
                        if (i == line.Length)
                        {
                            break;//データがなかったら抜ける
                        }
                    }
                    if (name_flag)
                    {
                        save_name[read_line_count] += line[i].ToString();
                    }
                    else if (data_flag)
                    {
                        save_data[read_line_count] += line[i].ToString();
                    }
                }
                if(data_name == save_name[read_line_count])
                {
                    return_index = read_line_count;
                    data = save_data[read_line_count];
                    index = read_line_count;
                }
                read_line_count++;
            }
            sr.Close();
        }
    }
    //FilecクラスはDataStorageクラスの名前がないもの、併用はできない。使うときは名前が行番号となる
    /// <summary>
    /// テキストファイルでのデータ保存（名前なし)
    /// </summary>
    public static class Filec
    {
        private static string[] save_data = new string[2048];
        /// <summary>
        /// ファイル内のラインを読み取る
        /// </summary>
        /// <param name="file_path">ファイルパス</param>
        /// <param name="line_index">読み取るラインの行を入力 0～2048</param>
        /// <returns></returns>
        public static string ReadLine(string file_path, int line_index)
        {

            if (File.Exists(file_path) == false)
            {
                using (FileStream fs = File.Create(file_path)) ;
            }
            int Readline = 0;
            string str = null;
            StreamReader sr = new StreamReader(file_path, Encoding.GetEncoding("UTF-8"));
            while (sr.Peek() != -1)
            {
                str = sr.ReadLine();
                if (Readline == line_index)
                {
                    break;
                }
                Readline++;
            }
            sr.Close();

            return str;
        }
        /// <summary>
        /// 指定した行に文字を挿入する
        /// </summary>
        /// <param name="file_path"></param>
        /// <param name="writing_data"></param>
        /// <param name="line_index"></param>
        public static void WriteLine(string file_path, string writing_data, int line_index)
        {
            for (int i = 0; i < 2048; i++)
            {
                save_data[i] = "";
            }
            if (File.Exists(file_path) == false)
            {
                File.Create(file_path).Close();
            }
            int Readline = 0;
            StreamReader sr = new StreamReader(file_path, Encoding.GetEncoding("UTF-8"));
            while (sr.Peek() != -1)
            {
                save_data[Readline] = sr.ReadLine(); //ファイルの中身をsave_data配列にしまう
                Readline++;
            }
            sr.Close();

            save_data[line_index] = writing_data; //新しく書き入れるデータを入れる
            File.Delete(file_path); //ファイルの中身を消すために一度削除する
            File.Create(file_path).Close(); //再び作成

            StreamWriter sw = new StreamWriter(file_path);
            if (line_index > Readline)
            {
                Readline = line_index;
            }
            for (int i = 0; i < Readline + 1; i++)
            {
                sw.Write(save_data[i] + "\n");
            }
            sw.Close(); // StreamWriter を閉じる
        }
    }
}

