import java.util.List;
import lejos.nxt.SensorPort;
import lejos.nxt.UltrasonicSensor;

public class Scanner extends Operator {

    public List<Pair<Double,Double>> map;

    @Override
    public Boolean Do() {
        TrackScan trackScan = new TrackScan(new UltrasonicSensor(SensorPort.S2));
        map= trackScan.map;
        InThread scanner = new InThread(trackScan);
        scanner.start();
        try {
            scanner.join();
        } catch (InterruptedException ex) {
        }
        return true;
    }
}
