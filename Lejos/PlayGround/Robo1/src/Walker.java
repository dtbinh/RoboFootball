import java.util.ArrayList;
import java.util.List;
import lejos.robotics.navigation.Waypoint;

public class Walker extends Operator{
    public List<Waypoint> Path = new ArrayList<>();
    //TODO:THis is very bad!! SHould be in separate operator!!!
    public Boolean reorient= false;
    
    @Override
    public Boolean Do() {
        TrackWalker trackWalker = new TrackWalker();
        trackWalker.reorientation=reorient;
        if(trackWalker.reorientation)
        {
            Waypoint first = Path.get(0);
            Path=new ArrayList<>();
            Path.add(first);
        }
        trackWalker.AddPath(Path);
        InThread walker = new InThread(trackWalker);
        walker.start();
        try {
            walker.join();
            trackWalker.ClearPath();
            reorient= false;
        } catch (InterruptedException ex) {
        }
        return true;
    }
    
}
