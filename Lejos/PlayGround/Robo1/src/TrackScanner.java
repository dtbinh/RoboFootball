import java.util.ArrayList;
import java.util.List;
import lejos.geom.Point;
import lejos.nxt.UltrasonicSensor;

public class TrackScanner extends TrackOperator {
    UltrasonicSensor sonar;
    List<Point> map;
    public float delta=10.0f;
    
    private Boolean terminate= false;
    @Override
    public void Terminate()
    {
        terminate= true;
    }
    
    public TrackScanner(UltrasonicSensor sonar) {
        this.map = new ArrayList<>();
        this.sonar = sonar;
    }
    
    @Override
    public Boolean Do() {
        int count = (int)(360.0/delta);
        for(int i=0;i<count; i++)
        {
            if(terminate)
            return true;
            
            float dgr=(i+1)*delta;
            
            turnAndMeasure(dgr);
        }
        terminate=true;
        return true;
    }
    
    private synchronized void turnAndMeasure(float dgr)
    {
        Double prevSpeed= pilot.getRotateSpeed();
        pilot.setRotateSpeed(pilot.getMaxRotateSpeed());
        pilot.rotate(delta);
        float r= sonar.getDistance();
        Point point = new Point((float) Math.toRadians(dgr));
        point=point.multiply(r);
        System.out.println(dgr);
        map.add(point);
        pilot.setRotateSpeed(prevSpeed);
    }
}
