public class InThread extends Thread 
{
    private Operator operator;
    private Boolean terminate=false;
    
    public InThread(Operator operator) 
    {
        this.operator=operator;
    } 
   
    @Override
    public void run() 
    {
        while (!terminate) 
        {
            try {
                terminate=operator.Do();
                Thread.sleep(1);
            } catch (InterruptedException ex) {
            }
        }
    }
}