using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Windows.Forms;

namespace TVDb
{
    class SqLiteDatabase
    {
        readonly String _dbConnection;

        /// <summary>
        ///     Default Constructor for SQLiteDatabase Class.
        /// </summary>
        public SqLiteDatabase()
        {
            _dbConnection = "Data Source=tvdb.db";
        }

        /// <summary>
        ///     Single Param Constructor for specifying the DB file.
        /// </summary>
        /// <param name="inputFile">The File containing the DB</param>
        public SqLiteDatabase(String inputFile)
        {
            _dbConnection = String.Format("Data Source={0}", inputFile);
        }

        /// <summary>
        ///     Single Param Constructor for specifying advanced connection options.
        /// </summary>
        /// <param name="connectionOpts">A dictionary containing all desired options and their values</param>
        public SqLiteDatabase(Dictionary<String, String> connectionOpts)
        {
            String str = connectionOpts.Aggregate("", (current, row) => current + String.Format("{0}={1}; ", row.Key, row.Value));
            str = str.Trim().Substring(0, str.Length - 1);
            _dbConnection = str;
        }

        /// <summary>
        ///     Allows the programmer to run a query against the Database.
        /// </summary>
        /// <param name="sql">The SQL to run</param>
        /// <returns>A DataTable containing the result set.</returns>
        public DataTable GetDataTable(string sql)
        {
            var dt = new DataTable();
            try
            {
                var cnn = new SQLiteConnection(_dbConnection);
                cnn.Open();
                var mycommand = new SQLiteCommand(cnn) {CommandText = sql};
                var reader = mycommand.ExecuteReader();
                dt.Load(reader);
                reader.Close();
                cnn.Close();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return dt;
        }

        /// <summary>
        ///     Allows the programmer to interact with the database for purposes other than a query.
        /// </summary>
        /// <param name="sql">The SQL to be run.</param>
        /// <returns>An Integer containing the number of rows updated.</returns>
        public int ExecuteNonQuery(string sql)
        {
            var cnn = new SQLiteConnection(_dbConnection);
            cnn.Open();
            var mycommand = new SQLiteCommand(cnn) {CommandText = sql};

            var rowsUpdated = mycommand.ExecuteNonQuery();
            cnn.Close();
            return rowsUpdated;
        }
        public int UpdateDate(string seriesId, string date)
        {
            var cnn = new SQLiteConnection(_dbConnection);
            cnn.Open();
            var mycommand = new SQLiteCommand(cnn)
                {
                    CommandText = "UPDATE series SET updated=@date WHERE series_id=" + seriesId
                };
            mycommand.Parameters.Add(new SQLiteParameter("@date", date));
            var rowsUpdated = mycommand.ExecuteNonQuery();
            cnn.Close();
            return rowsUpdated;
        }

        public bool EpisodeExists(string seriesId, string episodeId) {
            var cnn = new SQLiteConnection(_dbConnection);
            cnn.Open();
            var cmd = new SQLiteCommand(cnn)
                {
                    CommandText = "SELECT count(*) FROM episodes_" + seriesId + " WHERE episode_id=" + episodeId
                };
            var count = Convert.ToInt32(cmd.ExecuteScalar());
            cnn.Close();
            return count != 0;
        }

        public bool ShowExists(string seriesName)
        {
            var cnn = new SQLiteConnection(_dbConnection);
            cnn.Open();
            var cmd = new SQLiteCommand(cnn) {CommandText = "SELECT count(*) FROM series WHERE series_name=@seriesName"};
            cmd.Parameters.Add(new SQLiteParameter("@seriesName", seriesName));
            var count = Convert.ToInt32(cmd.ExecuteScalar());
            cnn.Close();
            return count != 0;
        }

        public int InsertEpisode(string tableName, EpisodeDatabaseEntry episode)
        {
            var cnn = new SQLiteConnection(_dbConnection);
            cnn.Open();
            var mycommand = new SQLiteCommand(cnn)
                {
                    CommandText =
                        "INSERT INTO " + tableName +
                        " (episode_name, episode, season, first_aired, imdb_id, overview, rating, episode_id, watched) VALUES(@episodeName, @episode, @season, @firstAired, @imdbId, @overview, @rating, @episode_id, @watched)"
                };
            mycommand.Parameters.Add(new SQLiteParameter("@episodeName", episode.EpisodeName));
            mycommand.Parameters.Add(new SQLiteParameter("@episode", episode.Episode));
            mycommand.Parameters.Add(new SQLiteParameter("@firstAired", episode.FirstAired));
            mycommand.Parameters.Add(new SQLiteParameter("@season", episode.Season));
            mycommand.Parameters.Add(new SQLiteParameter("@imdbId", episode.ImdbId));
            mycommand.Parameters.Add(new SQLiteParameter("@overview", episode.Overview));
            mycommand.Parameters.Add(new SQLiteParameter("@rating", episode.Rating));
            mycommand.Parameters.Add(new SQLiteParameter("@watched", episode.Watched));
            mycommand.Parameters.Add(new SQLiteParameter("@episode_id", episode.EpisodeId));
            var rowsUpdated = mycommand.ExecuteNonQuery();
            cnn.Close();
            return rowsUpdated;
        }
        public int UpdateEpisode(string seriesId, string episodeId, string episodeName, string overview, string firstAired, string rating)
        {
            var cnn = new SQLiteConnection(_dbConnection);
            cnn.Open();
            var mycommand = new SQLiteCommand(cnn)
                {
                    CommandText =
                        "UPDATE episodes_" + seriesId +
                        " SET episode_name=@episodeName, first_aired=@firstAired, overview=@overview, rating=@rating WHERE episode_id=" +
                        episodeId
                };
            mycommand.Parameters.Add(new SQLiteParameter("@episodeName", episodeName));
            mycommand.Parameters.Add(new SQLiteParameter("@overview", overview));
            mycommand.Parameters.Add(new SQLiteParameter("@rating", rating));
            mycommand.Parameters.Add(new SQLiteParameter("@firstAired", firstAired));
            var rowsUpdated = mycommand.ExecuteNonQuery();
            cnn.Close();
            return rowsUpdated;
        }
        /**/
        public int InsertSeries(SeriesDatabaseEntry series)
        {
            var cnn = new SQLiteConnection(_dbConnection);
            cnn.Open();
            var mycommand = new SQLiteCommand(cnn)
                {
                    CommandText =
                        "INSERT INTO series (series_name, first_aired, imdb_id, overview, rating, series_id, language, banner_local, banner_url, poster_local, poster_url, fanart_local, fanart_url, network, runtime, status, ignore_agenda, hide_from_list, updated) VALUES(@series_name, @first_aired, @imdb_id, @overview, @rating, @series_id, @language, @banner_local, @banner_url, @poster_local, @poster_url, @fanart_local, @fanart_url, @network, @runtime, @status, @ignore_agenda, @hide, @updated);",
                    CommandType = CommandType.Text
                };

            mycommand.Parameters.Add(new SQLiteParameter("@series_name", series.SeriesName));
            mycommand.Parameters.Add(new SQLiteParameter("@first_aired", series.FirstAired));
            mycommand.Parameters.Add(new SQLiteParameter("@imdb_id", series.ImdbId));
            mycommand.Parameters.Add(new SQLiteParameter("@overview", series.Overview));
            mycommand.Parameters.Add(new SQLiteParameter("@rating", series.Rating));
            mycommand.Parameters.Add(new SQLiteParameter("@series_id", series.SeriesId));
            mycommand.Parameters.Add(new SQLiteParameter("@language", series.Language));
            mycommand.Parameters.Add(new SQLiteParameter("@banner_local", series.BannerLocal));
            mycommand.Parameters.Add(new SQLiteParameter("@banner_url", series.BannerUrl));
            mycommand.Parameters.Add(new SQLiteParameter("@poster_local", series.PosterLocal));
            mycommand.Parameters.Add(new SQLiteParameter("@poster_url", series.PosterUrl));
            mycommand.Parameters.Add(new SQLiteParameter("@fanart_local", series.FanartLocal));
            mycommand.Parameters.Add(new SQLiteParameter("@fanart_url", series.FanartUrl));
            mycommand.Parameters.Add(new SQLiteParameter("@status", series.Status));
            mycommand.Parameters.Add(new SQLiteParameter("@network", series.Network));
            mycommand.Parameters.Add(new SQLiteParameter("@runtime", series.Runtime));
            mycommand.Parameters.Add(new SQLiteParameter("@ignore_agenda", series.Ignore));
            mycommand.Parameters.Add(new SQLiteParameter("@hide", series.Hide));
            mycommand.Parameters.Add(new SQLiteParameter("@updated", series.Updated));
            var rowsUpdated = mycommand.ExecuteNonQuery();
            cnn.Close();
            return rowsUpdated;
        }
        public int InsertArts(ArtsDatabaseEntry series, string tableName)
        {
            var cnn = new SQLiteConnection(_dbConnection);
            cnn.Open();
            var mycommand = new SQLiteCommand(cnn)
                {
                    CommandText = "INSERT INTO " + tableName + " (image) VALUES(@image);",
                    CommandType = CommandType.Text
                };

            mycommand.Parameters.Add(new SQLiteParameter("@image", series.BannerLocal));
            var rowsUpdated = mycommand.ExecuteNonQuery();
            cnn.Close();
            return rowsUpdated;
        }

        /// <summary>
        ///     Allows the programmer to retrieve single items from the DB.
        /// </summary>
        /// <param name="sql">The query to run.</param>
        /// <returns>A string.</returns>
        public string ExecuteScalar(string sql)
        {
            var cnn = new SQLiteConnection(_dbConnection);
            cnn.Open();
            var mycommand = new SQLiteCommand(cnn) {CommandText = sql};
            var value = mycommand.ExecuteScalar();
            cnn.Close();
            return value != null ? value.ToString() : "";
        }

        /// <summary>
        ///     Allows the programmer to easily update rows in the DB.
        /// </summary>
        /// <param name="tableName">The table to update.</param>
        /// <param name="data">A dictionary containing Column names and their new values.</param>
        /// <param name="where">The where clause for the update statement.</param>
        /// <returns>A boolean true or false to signify success or failure.</returns>
        public bool Update(String tableName, Dictionary<String, String> data, String where)
        {
            var vals = "";
            var returnCode = true;
            if (data.Count >= 1)
            {
                vals = data.Aggregate(vals, (current, val) => current + String.Format(" {0} = '{1}',", val.Key.ToString(), val.Value.ToString()));
                vals = vals.Substring(0, vals.Length - 1);
            }
            try
            {
                ExecuteNonQuery(String.Format("update {0} set {1} where {2};", tableName, vals, where));
            }
            catch
            {
                returnCode = false;
            }
            return returnCode;
        }

        /// <summary>
        ///     Allows the programmer to easily delete rows from the DB.
        /// </summary>
        /// <param name="tableName">The table from which to delete.</param>
        /// <param name="where">The where clause for the delete.</param>
        /// <returns>A boolean true or false to signify success or failure.</returns>
        public bool Delete(String tableName, String where)
        {
            Boolean returnCode = true;
            try
            {
                ExecuteNonQuery(String.Format("delete from {0} where {1};", tableName, where));
            }
            catch (Exception fail)
            {
                MessageBox.Show(fail.Message);
                returnCode = false;
            }
            return returnCode;
        }

        /// <summary>
        ///     Allows the programmer to easily insert into the DB
        /// </summary>
        /// <param name="tableName">The table into which we insert the data.</param>
        /// <param name="data">A dictionary containing the column names and data for the insert.</param>
        /// <returns>A boolean true or false to signify success or failure.</returns>
        public bool Insert(String tableName, Dictionary<String, String> data)
        {
            String columns = "";
            String values = "";
            Boolean returnCode = true;
            foreach (KeyValuePair<String, String> val in data)
            {
                columns += String.Format(" {0},", val.Key.ToString());
                values += String.Format(" '{0}',", val.Value);
            }
            columns = columns.Substring(0, columns.Length - 1);
            values = values.Substring(0, values.Length - 1);
            try
            {
                ExecuteNonQuery(String.Format("insert into {0}({1}) values({2});", tableName, columns, values));
            }
            catch (Exception fail)
            {
                MessageBox.Show(fail.Message);
                returnCode = false;
            }
            return returnCode;
        }

        /// <summary>
        ///     Allows the programmer to easily delete all data from the DB.
        /// </summary>
        /// <returns>A boolean true or false to signify success or failure.</returns>
        public bool ClearDb()
        {
            try
            {
                var tables = GetDataTable("select NAME from SQLITE_MASTER where type='table' order by NAME;");
                foreach (DataRow table in tables.Rows)
                {
                    ClearTable(table["NAME"].ToString());
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        ///     Allows the user to easily clear all data from a specific table.
        /// </summary>
        /// <param name="table">The name of the table to clear.</param>
        /// <returns>A boolean true or false to signify success or failure.</returns>
        public bool ClearTable(String table)
        {
            try
            {

                ExecuteNonQuery(String.Format("delete from {0};", table));
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool CreateTable(String query) {
            var returnCode = true;
            try
            {
                ExecuteNonQuery(query);
            }
            catch (Exception fail)
            {
                MessageBox.Show(fail.Message);
                returnCode = false;
            }
            return returnCode;
        }
    }
}


