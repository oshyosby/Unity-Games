
namespace MiniGames {
    namespace RockPaperScissors {

        using Framework;

        public class Game : Framework.Game {
            public Game() : 
            base("Rock Paper Scissors", Objects.List()) {}

            public Record NewPlayer(string firstName, string lastName) {
                Record player = SDataModel.GetSObjectByName("player").NewRecord(
                    new Dictionary<string,object>{
                        {"firstName", firstName},
                        {"lastName", lastName},
                        {"name", firstName+" "+lastName},
                        {"wins", 0},
                        {"losses", 0},
                        {"draws", 0}
                    }
                );
                player.Insert();
                return player;
            }

            public Record NewMatch(Record player1, Record player2) {
                Record match = SDataModel.GetSObjectByName("match").NewRecord(
                    new Dictionary<string,object>{
                        {"player1",player1.Id},
                        {"player2",player2.Id},
                        {"name",player1.Name+" vs "+player2.Name}
                    }
                ); 
                match.Insert();
                return match;
            }
        }

        public static class Objects {
            private static SObject Match() {
                SObject sObject = new SObject("match","Match","mat");
                List<Field> fields = new List<Field>{
                    new Field("player1","Player 1","lookup",true),
                    new Field("player2","Player 2","lookup",true),
                    new Field("player1Move","Player 1 Move","string",false),
                    new Field("player2Move","Player 2 Move","string",false)
                };
                sObject.NewFields(fields);
                return sObject;
            }
            private static SObject Player() {
                SObject sObject = new SObject("player","Player","ply");
                List<Field> fields = new List<Field>{
                    new Field("firstName","First Name","string",true),
                    new Field("lastName","Last Name","string",true),
                    new Field("wins","Wins","int",true),
                    new Field("losses","Losses","int",true),
                    new Field("draws","Draws","int",true)
                };
                sObject.NewFields(fields);
                return sObject;
            }  

            public static List<SObject> List() {
                return new List<SObject>
                {Match(), Player()};
            }
        }
    }
}