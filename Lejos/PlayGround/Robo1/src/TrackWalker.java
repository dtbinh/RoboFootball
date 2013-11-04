import lejos.robotics.navigation.Navigator;
import lejos.robotics.navigation.Waypoint;

public class TrackWalker extends TrackOperator {
    Navigator navigator = new Navigator(pilot);
    @Override
    public Boolean Do() {
        navigator.clearPath();
        navigator.followPath();
        return true;
    }
    
    public void AddWayPoint(float x,float y)
    {
        navigator.addWaypoint(new Waypoint(x,y));
    }

    private Boolean terminate= false;
    @Override
    public void Terminate()
    {
        terminate= true;
    }
}
