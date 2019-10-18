using DesafioUtils.NunitHelpers;
using System;
using System.Collections.Generic;
using System.IO;

namespace DesafioUtils.AchivesHelpres
{
    public class _PlaylistTestHelper
    {

        //forte candidata a ser apagada, nao sei pra q serve
        public static string path;
        public static string nomeArquivo;
        public static string extensao;
        public static string failedTest;
        public static StreamWriter writer;
        public static List<String> listaTestes;

        public static void CreatePlaylistArchive()
        {
            if (writer == null)
            {
                path = GetCurrentContextTestHelper.GetTestDirectoryName();

                nomeArquivo = path + "Falha_" + DateTime.Now.ToString(" dd-MM-yyyy");
                extensao = ".txt";
                writer = new StreamWriter(nomeArquivo + extensao);
                AddLine("<Playlist Version=\"1.0\">");

            }

        }

        public static void AddTestToPlaylist()
        {

            var status = GetCurrentContextTestHelper.GetTestResult();

            if (status.ToString() == "Failed")
            {
                if (GetCurrentContextTestHelper.GetFullTestName() != failedTest)
                {
                    failedTest = GetCurrentContextTestHelper.GetFullTestName();
                    writer.WriteLine("<Add Test=\"" + GetCurrentContextTestHelper.GetFullTestName() + "\" /> ");
                }
            }
        }

        public static void AddLine(String text)
        {
            writer.WriteLine(text);

        }
        public static void WriteAndClosePlaylist()
        {
            AddLine("</Playlist>");
            writer.Close();
        }

    }
}
