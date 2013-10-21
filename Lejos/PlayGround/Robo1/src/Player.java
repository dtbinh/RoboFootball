
import java.util.List;
import lejos.nxt.Button;
import lejos.nxt.Motor;

public class Player {

    Operator kick = new KickerKick();
    Operator toPosition = new KickerToPosition();
    Scanner scanner = new Scanner();
    public Player() {
        KickerOperator.kicker = Motor.A;
        toPosition.Do();

    }

    public static void main(String[] args) throws InterruptedException {

        System.out.println(" Robo 1 ");
        System.out.println(" Press Button To Start ");
        Button.waitForAnyPress();

        Player player = new Player();
        System.out.println(" Started ");

        
        List<Pair<Double,Double>> map= player.ScanForSomething();
        
        for(Pair<Double,Double> m : map)
        {
            System.out.println(" Angle: "+m.getLeft()+" Distance: "+m.getRight());
            Thread.sleep(1000);
        }
        
        
        System.out.println(" wait to quit ");
        Button.waitForAnyPress();
    }

    private List<Pair<Double,Double>> ScanForSomething()
    {
        scanner.Do();
        return scanner.map;    
    }
    
    private void KickSomething() {
        kick.Do();
        toPosition.Do();
    }
    
    
    
    
    public void GoTo(int x, int y) {
    }
}