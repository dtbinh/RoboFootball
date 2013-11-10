import java.util.List;
import lejos.geom.Point;
import lejos.robotics.navigation.Navigator;
import lejos.robotics.navigation.Waypoint;

public class TrackWalker extends TrackOperator {
    Navigator navigator = new Navigator(pilot);
    Boolean reorientation= false;
    float angle; 
    @Override
    public Boolean Do() {
        if(reorientation)
        {
            return Orient(); // remove this to separate action!
        }
        System.out.println("on the path");
        for (Waypoint wp: navigator.getPath())
            System.out.println(wp.x+" "+wp.y);
        navigator.followPath();
        return true;
    }
    
    public void AddPath(List<Waypoint> wayPoints)
    {
        reorientation= false;
        for(Waypoint wp:wayPoints)
            navigator.addWaypoint(wp);
    }

    public Boolean Orient()
    {
        angle=navigator
                .getPoseProvider()
                .getPose()
                .angleTo(navigator.getPath().get(0));
        pilot.rotate(angle);
        reorientation=false;
        System.out.println("Reorientation is on!");
        return true;
    }
    
    
    private Boolean terminate= false;
    @Override
    public void Terminate()
    {
        terminate= true;
    }
    
    public void ClearPath()
    {
        navigator.clearPath();
    }
}
