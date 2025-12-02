class Program
{
  public int[] expensesCost;

  static void Main(string[] args)
  {
    Console.WriteLine("Entre com o número de despesas: ");
    int numberOfExpenses = getNumberOfExpenses();

    expensesCost = new int[numberOfExpenses];
  }
}