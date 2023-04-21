using System.Diagnostics;

namespace osiCR;

public class task1
{
    private int _isActive;
    private int PID1;
    private int PID2;

    public void Watcher()
    {
       PID1 = Convert.ToInt32(Console.ReadLine());
       PID2 = Convert.ToInt32(Console.ReadLine());
       
       
        Thread myThread1 = new Thread(obs);
        myThread1.Start(PID1);
        Thread.Sleep(30000);
        
        if (ProcessExists(PID1))
        {
            Console.WriteLine("timeout");
        }
    }

    void obs(object? x)
    {
        int id = Convert.ToInt32(x);
        while (true)
        {
            if (!ProcessExists(id))
            {
                IsActive = 0;
                break;
            }
            else Thread.Sleep(10);
        }
    }
    
    public int IsActive
    {
        get { return _isActive; }
        set
        {
            _isActive = value;
            if (_isActive == 0)
            {
                var pr = Process.GetProcessById(PID2);
                pr.Kill();
            }
        }
    }
    
    private bool ProcessExists(int id)
    {
        return Process.GetProcesses().Any(x => x.Id == id);
    }
}