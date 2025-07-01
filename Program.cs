RockPaperScissors game = new RockPaperScissors("Vlada", "Ichi");
game.Start();

class RockPaperScissors {
  private Player Player1 {get; set;}
  private Player Player2 {get; set;}
  private Round Rounds {get; set;}

  public RockPaperScissors (string player1, string player2) {
    Player1 = new Player(player1);
    Player2 = new Player(player2);
    Rounds = new Round(Player1, Player2);
  }

  public void Start() {
    int counter = 0;
    while (counter < 10) {
      Rounds.Start();
      counter++;
    }
    Console.WriteLine("Game Over");
    Rounds.History();
  }
}

class Player {
  public string Name {get; private set;}
  public Hands Hand {get; private set;}
  
  public Player (string name) {
    Name = name;
  }
  public void makeHand() {
    int choice = 0;
    while (choice < 1 || choice > 3) {
    Console.WriteLine($"{Name} select your hand:\n1. Rock\n2. Paper\n3. Scissors");
    ConsoleKeyInfo keyInfo = Console.ReadKey(true); // true means don't show input in console. 
    if (keyInfo.Key == ConsoleKey.D1){
      choice = 1;
      }
    else if (keyInfo.Key == ConsoleKey.D2) {
        choice = 2;
      }
    else if (keyInfo.Key == ConsoleKey.D3) {
        choice = 3;
      }
    else {
        choice = 0;
      }
    }
    if (choice == 1) {
      Hand = Hands.Rock;
      }
    if (choice == 2) {
      Hand = Hands.Paper;
      }
    if (choice == 3) {
      Hand = Hands.Scissors;
      }
  }
}

class Round {
  public Player Player1 {get; private set;}
  public Player Player2 {get; private set;}
  public int NumberOfRound {get; set;}
  private GameHistory RecordOfRounds {get; set;}

  public Round (Player player1, Player player2) {
   Player1 = player1; 
   Player2 = player2; 
   NumberOfRound = 1;
   RecordOfRounds = new GameHistory();
  }

  public void Start() {
    Player1.makeHand();
    Player2.makeHand();
    Console.Clear();
    if (Player1.Hand == Player2.Hand) {
      Console.WriteLine($"Round {NumberOfRound}: Tie");
      RecordOfRounds.Add(NumberOfRound, "Tie");
    }
    else if (
        (Player1.Hand == Hands.Rock && Player2.Hand == Hands.Paper) || 
        (Player1.Hand == Hands.Paper && Player2.Hand == Hands.Scissors) || 
        (Player1.Hand == Hands.Scissors && Player2.Hand == Hands.Rock) 
        ) {
      Console.WriteLine($"Round {NumberOfRound}: {Player2.Name} won!");
      RecordOfRounds.Add(NumberOfRound, Player2.Name);
    }
    else{
      Console.WriteLine($"Round {NumberOfRound}: {Player1.Name} won!");
      RecordOfRounds.Add(NumberOfRound, Player1.Name);
    }
      NumberOfRound++;
  }
  public void History(){
    RecordOfRounds.All();
  }
}

class GameHistory {
  public Dictionary<int, string> History {get; private set;} 

  public GameHistory() {
    History = new Dictionary <int, string>();
  }

  public void Add(int round, string winner){
    History.Add(round, winner);
  }
  public void All() {
    foreach (var round in History) {
      if (round.Value == "Tie") {
      Console.WriteLine($"Round: {round.Key}. Tie.");
      }
      else
      Console.WriteLine($"Round: {round.Key}. {round.Value} won.");
    }
  }
}


enum Hands {Rock, Paper, Scissors}
