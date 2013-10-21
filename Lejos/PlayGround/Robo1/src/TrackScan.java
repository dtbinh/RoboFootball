import java.util.ArrayList;
import java.util.List;
import lejos.nxt.UltrasonicSensor;

public class TrackScan extends TrackOperator {
    UltrasonicSensor sonar;
    List<Pair<Double,Double>> map;
    public Double delta=30.0;
    
    private Boolean terminate= false;
    public void Terminate()
    {
        terminate= true;
    }
    
    public TrackScan(UltrasonicSensor sonar) {
        this.map = new ArrayList<>();
        this.sonar = sonar;
    }
    
    @Override
    public Boolean Do() {
        int count = (int)(360.0/delta);
        System.out.println("Scanning "+count);
        for(int i=0;i<count; i++)
        {
            System.out.println("Scanning "+i*delta);
            if(terminate)
            return true;
            turnAndMeasure(i*delta);
        }
        System.out.println("ololol! ");
        terminate=true;
        return true;
    }
    
    private synchronized void turnAndMeasure(Double dgr)
    {
        pilot.setRotateSpeed(100);
        pilot.rotate(delta);
        map.add(new Pair<>(dgr,new Double(sonar.getDistance())));
    }
}
