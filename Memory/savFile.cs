using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using SpssLib.DataReader;
using SpssLib.FileParser;
using SpssLib.SpssDataset;
using System.Diagnostics;
using System.IO;
using Newtonsoft.Json;

namespace Memory
{
    class savFile
    {

        string file;

        public savFile(string fileName)
        {
            this.file = fileName;
        }

        public List<Highscore> getHighscores()
        {
            List<Highscore> values = new List<Highscore>();
            FileStream filestream = new FileStream("../../" + file, FileMode.Open, FileAccess.Read, FileShare.Read, 2048 * 10, FileOptions.SequentialScan);
            SpssReader sppsDataset = new SpssReader(filestream);

            foreach (var variable in sppsDataset.Variables)
            {
                if (variable.Name != "Default")
                {
                    data d = JsonConvert.DeserializeObject<data>(variable.Label);
                    values.Add(new Highscore() { Name = variable.Name, Score = d.Score, Outcome = d.Outcome });
                }
            }

            filestream.Close();
            return values;
        }

        [Obsolete]
        public void writeHighscore(string name, List<string> data)
        {
            FileStream readStream = new FileStream("../../" + file, FileMode.Open, FileAccess.Read, FileShare.Read, 2048 * 10, FileOptions.SequentialScan);
            SpssReader sppsDataset = new SpssReader(readStream);
            var variables = new List<Variable>();

            data h = new data
            {
                Score = data[0],
                Outcome = data[1]
            };

            string serializedJSON = JsonConvert.SerializeObject(h);

            foreach (var variable in sppsDataset.Variables)
            {
                variables.Add(
                    new Variable
                    {
                        Label = variable.Label,
                        Name = variable.Name,
                        PrintFormat = new OutputFormat(FormatType.F, 8, 2),
                        WriteFormat = new OutputFormat(FormatType.F, 8, 2),
                        Type = DataType.Numeric,
                        Width = 10,
                        MissingValueType = MissingValueType.NoMissingValues
                    });
            }

            readStream.Close();

            variables.Add(
                new Variable
                    {
                        Name = name,
                        Label = serializedJSON,
                        PrintFormat = new OutputFormat(FormatType.F, 8, 2),
                        WriteFormat = new OutputFormat(FormatType.F, 8, 2),
                        Type = DataType.Numeric,
                        Width = 10,
                        MissingValueType = MissingValueType.NoMissingValues
                    }
                );

            variables[1].MissingValues[0] = 999;

            var options = new SpssOptions();

            using (FileStream writeStream = new FileStream("../../" + file, FileMode.Create, FileAccess.Write))
            {
                using (var writer = new SpssWriter(writeStream, variables, options))
                {
                    var newRecord = writer.CreateRecord();
                    newRecord[0] = 15d;
                    newRecord[1] = 15.5d;
                    writer.WriteRecord(newRecord);

                    newRecord = writer.CreateRecord();
                    newRecord[0] = null;
                    newRecord[1] = 200d;
                    writer.WriteRecord(newRecord);
                    writer.EndFile();
                }

                writeStream.Close();
            }
        }

        [Obsolete]
        public List<savedGame> getGames()
        {
            List<savedGame> values = new List<savedGame>();
            FileStream filestream = new FileStream("../../" + file, FileMode.Open, FileAccess.Read, FileShare.Read, 2048 * 10, FileOptions.SequentialScan);
            SpssReader sppsDataset = new SpssReader(filestream);

            foreach (var variable in sppsDataset.Variables)
            {
                if (variable.Name != "Default")
                {
                    savedGame s = JsonConvert.DeserializeObject<savedGame>(variable.Label);
                    values.Add(new savedGame() { GameName = s.GameName, Status = s.Status, Players = s.Players, Score1 = s.Score1, Score2 = s.Score2, Turn = s.Turn });
                }
            }

            filestream.Close();
            return values;
        }
        /// <summary>
        /// A function which writes a given game to the .sav file
        /// </summary>
        /// <param name="name">The name of the game</param>
        /// <param name="data">A list of strings containing data about the players</param>
        /// <param name="scores">A list containing lists of ints</param>
        [Obsolete]

        public void writeGame(string name, List<string> data, List<List<List<int>>> scores)
        {
            // A readstream which reads all data from the .sav file
            FileStream readStream = new FileStream("../../" + file, FileMode.Open, FileAccess.Read, FileShare.Read, 2048 * 10, FileOptions.SequentialScan);
            SpssReader sppsDataset = new SpssReader(readStream);
            var variables = new List<Variable>();

            // a new savedGame model is instantiated and occupied with data
            savedGame s = new savedGame
            {
                GameName = name,
                Status = scores,
                Players = new players() { player1 = data[0], player2 = data[1] },
                Score1 = data[2],
                Score2 = data[3],
                Turn = data[4]
            };

            // the model is converted to a JSON string
            string serializedJSON = JsonConvert.SerializeObject(s);

            // The readstream is read, and the individual variable objects are put into the variables list
            foreach (var variable in sppsDataset.Variables)
            {
                variables.Add(
                    new Variable
                    {
                        Label = variable.Label,
                        Name = variable.Name,
                        PrintFormat = new OutputFormat(FormatType.F, 8, 2),
                        WriteFormat = new OutputFormat(FormatType.F, 8, 2),
                        Type = DataType.Numeric,
                        Width = 10,
                        MissingValueType = MissingValueType.NoMissingValues
                    });
            }

            readStream.Close();

            variables.Add(
                new Variable
                {
                    Name = name,
                    Label = serializedJSON,
                    PrintFormat = new OutputFormat(FormatType.F, 8, 2),
                    WriteFormat = new OutputFormat(FormatType.F, 8, 2),
                    Type = DataType.Numeric,
                    Width = 10,
                    MissingValueType = MissingValueType.NoMissingValues
                }
                );

            variables[1].MissingValues[0] = 999;

            var options = new SpssOptions();

            using (FileStream writeStream = new FileStream("../../" + file, FileMode.Create, FileAccess.Write))
            {
                using (var writer = new SpssWriter(writeStream, variables, options))
                {
                    var newRecord = writer.CreateRecord();
                    newRecord[0] = 15d;
                    newRecord[1] = 15.5d;
                    writer.WriteRecord(newRecord);

                    newRecord = writer.CreateRecord();
                    newRecord[0] = null;
                    newRecord[1] = 200d;
                    writer.WriteRecord(newRecord);
                    writer.EndFile();
                }

                writeStream.Close();
            }
        }

        [Obsolete]
        public void clearData()
        {
            var variables = new List<Variable>();

            variables.Add(
                new Variable
                {
                    Label = "Default",
                    Name = "Default",
                    PrintFormat = new OutputFormat(FormatType.F, 8, 2),
                    WriteFormat = new OutputFormat(FormatType.F, 8, 2),
                    Type = DataType.Numeric,
                    Width = 10,
                    MissingValueType = MissingValueType.NoMissingValues
                }
            );

            var options = new SpssOptions();

            using (FileStream writeStream = new FileStream("../../" + file, FileMode.Create, FileAccess.Write))
            {
                using (var writer = new SpssWriter(writeStream, variables, options))
                {
                    var newRecord = writer.CreateRecord();
                    writer.WriteRecord(newRecord);
                    writer.EndFile();
                }

                writeStream.Close();
            }
        }
    }
}
