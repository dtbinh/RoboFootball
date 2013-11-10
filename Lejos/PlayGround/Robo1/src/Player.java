
import java.util.List;
import lejos.geom.Point;
import lejos.nxt.Button;
import lejos.nxt.Motor;
import lejos.robotics.navigation.Waypoint;

public class Player {

    Operator kick = new KickerKick();
    Operator toPosition = new KickerToPosition();
    Scanner scanner = new Scanner();
    Walker walker = new Walker();
    
    Point gate= new Point(35,0);  
    
    float RoboR= 10.0f;
    
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
        
        Point position= player.calculateWayPoint(closestPoint);
        
        System.out.println("position: "+position.x+" "+position.y);
        
        this does not work!
        player.walker.Path.add(new Waypoint(position));
        player.walker.Do();
        Walker is not wolk thru path Create separete project and make it work!
        player.walker.reorient=true;
        player.walker.Path.add(new Waypoint(player.gate));
        player.walker.Do();
        player.KickSomething();
        System.out.println(" wait to quit ");
        Button.waitForAnyPress();
    }
    
    private Point calculateWayPoint(Point ball)
    {
        Point v= ball.add(gate.reverse());
        Point vn=v.getNormalized();
        return vn.multiply(RoboR).add(ball);
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