using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;
using TVDb;

class SQLiteDatabase
{
    String dbConnection;

    /// <summary>
    ///     Default Constructor for SQLiteDatabase Class.
    /// </summary>
    public SQLiteDatabase()
    {
        dbConnection = "Data Source=tvdb.db";
    }

    /// <summary>
    ///     Single Param Constructor for specifying the DB file.
    /// </summary>
    /// <param name="inputFile">The File containing the DB</param>
    public SQLiteDatabase(String inputFile)
    {
        dbConnection = String.Format("Data Source={0}", inputFile);
    }

    /// <summary>
    ///     Single Param Constructor for specifying advanced connection options.
    /// </summary>
    /// <param name="connectionOpts">A dictionary containing all desired options and their values</param>
    public SQLiteDatabase(Dictionary<String, String> connectionOpts)
    {
        String str = "";
        foreach (KeyValuePair<String, String> row in connectionOpts)
        {
            str += String.Format("{0}={1}; ", row.Key, row.Value);
        }
        str = str.Trim().Substring(0, str.Length - 1);
        dbConnection = str;
    }

    /// <summary>
    ///     Allows the programmer to run a query against the Database.
    /// </summary>
    /// <param name="sql">The SQL to run</param>
    /// <returns>A DataTable containing the result set.</returns>
    public DataTable GetDataTable(string sql)
    {
        DataTable dt = new DataTable();
        try
        {
            SQLiteConnection cnn = new SQLiteConnection(dbConnection);
            cnn.Open();
            SQLiteCommand mycommand = new SQLiteCommand(cnn);
            mycommand.CommandText = sql;
            SQLiteDataReader reader = mycommand.ExecuteReader();
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
        SQLiteConnection cnn = new SQLiteConnection(dbConnection);
        cnn.Open();
        SQLiteCommand mycommand = new SQLiteCommand(cnn);
        mycommand.CommandText = sql;

        int rowsUpdated = mycommand.ExecuteNonQuery();
        cnn.Close();
        return rowsUpdated;
    }

    public int InsertEpisode(string tableName, EpisodeDatabaseEntry episode)
    {
        SQLiteConnection cnn = new SQLiteConnection(dbConnection);
        cnn.Open();
        SQLiteCommand mycommand = new SQLiteCommand(cnn);
        mycommand.CommandText = "INSERT INTO "+tableName+" (episode_name, episode, season, first_aired, imdb_id, overview, rating, episode_id, watched) VALUES(@episodeName, @episode, @season, @firstAired, @imdbId, @overview, @rating, @episode_id, @watched)";
        mycommand.Parameters.Add(new SQLiteParameter("@episodeName", episode.episodeName));
        mycommand.Parameters.Add(new SQLiteParameter("@episode", episode.episode));
        mycommand.Parameters.Add(new SQLiteParameter("@firstAired", episode.firstAired));
        mycommand.Parameters.Add(new SQLiteParameter("@season", episode.season));
        mycommand.Parameters.Add(new SQLiteParameter("@imdbId", episode.imdbId));
        mycommand.Parameters.Add(new SQLiteParameter("@overview", episode.overview));
        mycommand.Parameters.Add(new SQLiteParameter("@rating", episode.rating));
        mycommand.Parameters.Add(new SQLiteParameter("@watched", episode.watched));
        mycommand.Parameters.Add(new SQLiteParameter("@episode_id", episode.episodeId));
        int rowsUpdated = mycommand.ExecuteNonQuery();
        cnn.Close();
        return rowsUpdated;
    }
   /* public int CreateEpisodesTable(string tableName)
    {
        SQLiteConnection cnn = new SQLiteConnection(dbConnection);
        cnn.Open();
        SQLiteCommand mycommand = new SQLiteCommand(cnn);
        mycommand.CommandText = "CREATE TABLE @tableName" + "("
                        + "_id" + " INTEGER PRIMARY KEY,"
                        + "episode" + " INTEGER,"
                        + "season" + " INTEGER,"
                        + "episode_name" + " TEXT,"
                        + "first_aired" + " TEXT,"
                        + "imdb_id" + " TEXT,"
                        + "overview" + " TEXT,"
                        + "rating" + " DOUBLE,"
                        + "episode_id" + " INTEGER,"
                        + "watched" + " BOOLEAN"
                        +
                        ")";
            mycommand.Parameters.Add(new SQLiteParameter("@tableName", tableName+"episodes"));
        int rowsUpdated = mycommand.ExecuteNonQuery();
        cnn.Close();
        return rowsUpdated;
    }*/
    /**/
    public int InsertSeries(SeriesDatabaseEntry series)
    {
        SQLiteConnection cnn = new SQLiteConnection(dbConnection);
        cnn.Open();
        SQLiteCommand mycommand = new SQLiteCommand(cnn);

        mycommand.CommandText = "INSERT INTO series (series_name, first_aired, imdb_id, overview, rating, series_id, language, banner_local, banner_url, poster_local, poster_url, fanart_local, fanart_url, network, runtime, status, ignore, hide) VALUES(@series_name, @first_aired, @imdb_id, @overview, @rating, @series_id, @language, @banner_local, @banner_url, @poster_local, @poster_url, @fanart_local, @fanart_url, @network, @runtime, @status, @ignore, @hide);";
        mycommand.CommandType = CommandType.Text;
        mycommand.Parameters.Add(new SQLiteParameter("@series_name", series.seriesName));
        mycommand.Parameters.Add(new SQLiteParameter("@first_aired", series.firstAired));
        mycommand.Parameters.Add(new SQLiteParameter("@imdb_id", series.imdbId));
        mycommand.Parameters.Add(new SQLiteParameter("@overview", series.overview));
        mycommand.Parameters.Add(new SQLiteParameter("@rating", series.rating));
        mycommand.Parameters.Add(new SQLiteParameter("@series_id", series.seriesId));
        mycommand.Parameters.Add(new SQLiteParameter("@language", series.language));
        mycommand.Parameters.Add(new SQLiteParameter("@banner_local", series.bannerLocal));
        mycommand.Parameters.Add(new SQLiteParameter("@banner_url", series.bannerUrl));
        mycommand.Parameters.Add(new SQLiteParameter("@poster_local", series.posterLocal));
        mycommand.Parameters.Add(new SQLiteParameter("@poster_url", series.posterUrl));
        mycommand.Parameters.Add(new SQLiteParameter("@fanart_local", series.fanartLocal));
        mycommand.Parameters.Add(new SQLiteParameter("@fanart_url", series.fanartUrl));
        mycommand.Parameters.Add(new SQLiteParameter("@status", series.status));
        mycommand.Parameters.Add(new SQLiteParameter("@network", series.network));
        mycommand.Parameters.Add(new SQLiteParameter("@runtime", series.runtime));
        mycommand.Parameters.Add(new SQLiteParameter("@ignore", series.ignore));
        mycommand.Parameters.Add(new SQLiteParameter("@hide", series.hide));
        int rowsUpdated = mycommand.ExecuteNonQuery();
        cnn.Close();
        return rowsUpdated;
    }
    public int InsertArts(ArtsDatabaseEntry series, string tableName)
    {
        SQLiteConnection cnn = new SQLiteConnection(dbConnection);
        cnn.Open();
        SQLiteCommand mycommand = new SQLiteCommand(cnn);

        mycommand.CommandText = "INSERT INTO "+tableName+" (image) VALUES(@image);";
        mycommand.CommandType = CommandType.Text;
        mycommand.Parameters.Add(new SQLiteParameter("@image", series.bannerLocal));
        int rowsUpdated = mycommand.ExecuteNonQuery();
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
        SQLiteConnection cnn = new SQLiteConnection(dbConnection);
        cnn.Open();
        SQLiteCommand mycommand = new SQLiteCommand(cnn);
        mycommand.CommandText = sql;
        object value = mycommand.ExecuteScalar();
        cnn.Close();
        if (value != null)
        {
            return value.ToString();
        }
        return "";
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
        String vals = "";
        Boolean returnCode = true;
        if (data.Count >= 1)
        {
            foreach (KeyValuePair<String, String> val in data)
            {
                vals += String.Format(" {0} = '{1}',", val.Key.ToString(), val.Value.ToString());
            }
            vals = vals.Substring(0, vals.Length - 1);
        }
        try
        {
            this.ExecuteNonQuery(String.Format("update {0} set {1} where {2};", tableName, vals, where));
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
            this.ExecuteNonQuery(String.Format("delete from {0} where {1};", tableName, where));
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
            this.ExecuteNonQuery(String.Format("insert into {0}({1}) values({2});", tableName, columns, values));
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
    public bool ClearDB()
    {
        DataTable tables;
        try
        {
            tables = this.GetDataTable("select NAME from SQLITE_MASTER where type='table' order by NAME;");
            foreach (DataRow table in tables.Rows)
            {
                this.ClearTable(table["NAME"].ToString());
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

            this.ExecuteNonQuery(String.Format("delete from {0};", table));
            return true;
        }
        catch
        {
            return false;
        }
    }

    public bool createTable(String query) {
        Boolean returnCode = true;
        try
        {
            this.ExecuteNonQuery(query);
        }
        catch (Exception fail)
        {
            MessageBox.Show(fail.Message);
            returnCode = false;
        }
        return returnCode;
    }
}


