namespace osiCR;

public class task2
{
    public int[,] matrixA;
    public int[,] matrixB;
    public int[,] matrixRES;
    private int N;

    public task2(int n)
    {
        N = n;
        Random rand = new Random();
        matrixA = new int[n, n];
        matrixB = new int[n, n];
        matrixRES = new int[n, n];

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                matrixA[i, j] = rand.Next(10);
                matrixB[i, j] = rand.Next(10);
            }
        }
        
       PrintMatrix(matrixA);
       Console.WriteLine();
       PrintMatrix(matrixB);
    }

    public void MatrixSum()
    {
        List < Thread > threads= new List<Thread>();
        for (int i = 0; i < N; i++)
        {
            var tr = new Thread(MatrixRowSum);
            threads.Add(tr);
        }

        for (int i = 0; i < N; i++)
        {
            threads[i].Start(i);
        }
        Thread.Sleep(200);
        Console.WriteLine();
       PrintMatrix(matrixRES);
    }

    void MatrixRowSum(object? x)
    {
        for (int i = 0; i < N; i++)
        {
            matrixRES[(int)x, i] = matrixA[(int)x, i] - matrixB[(int)x, i];
        }
    }

    void PrintMatrix(int[,] mtr)
    {
        for (int i = 0; i < N; i++)
        {
            string s = "";
            for (int j = 0; j < N; j++)
            {
                s += mtr[i, j] + " ";
            }
            Console.WriteLine(s);
        }
    }
}