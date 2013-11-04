
import java.util.List;
import lejos.geom.Point;
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

        Point closestPoint = player.ScanForSomething();

        System.out.println("Closest: "+closestPoint.x+" "+closestPoint.y);
        System.out.println("dist: "+closestPoint.length());
        
        
        
        

        System.out.println(" wait to quit ");
        Button.waitForAnyPress();
    }

    private Point ScanForSomething() {
        scanner.Do();
        List<Point> map = scanner.map;
        Point closestPoint = new Point(0.0f, 255.0f);
        for (Point point : map) {
            if (point.length() < closestPoint.length()) {
                closestPoint = point;
            }
        }
        return closestPoint;
    }

    private void KickSomething() {
        kick.Do();
        toPosition.Do();
    }

    public void GoTo(int x, int y) {
    }
}