// using api_rra1.ClassModels;
// using MySql.Data.MySqlClient;

// namespace api_rra1.ClassModels.Database
// {
//     public class UpdateSong
//     {
//         public static void ChangeSong(string id, Song mySong)
//         {
//             DBConnect db = new DBConnect();
//             bool isOpen = db.OpenCon();
//             if (isOpen)
//             {
//                 string stm = @"UPDATE songs SET isFavorited=@isFavorited, isDeleted=@isDeleted, songTitle=@songTitle, songArtist=@songArtist WHERE songID =@id";
//                 MySqlConnection con = db.GetCon();
//                 using var cmd = new MySqlCommand(stm, con);
//                 cmd.Parameters.AddWithValue("@songID", mySong.songID);
//                 cmd.Parameters.AddWithValue("@songTitle", mySong.songTitle);
//                 cmd.Parameters.AddWithValue("@songArtist", mySong.songArtist);
//                 cmd.Parameters.AddWithValue("@isFavorited", mySong.isFavorited);
//                 cmd.Parameters.AddWithValue("@isDeleted", mySong.isDeleted);
//                 cmd.Parameters.AddWithValue("id", id);
//                 cmd.Prepare();
//                 cmd.ExecuteNonQuery();
//             }
//             else
//             {
//                 System.Console.WriteLine("Failed to Save Song");
//             }
//             db.CloseCon();
//         }
//     }
// }