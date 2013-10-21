
import lejos.nxt.SensorPort;
import lejos.nxt.TouchSensor;

public class KickerToPosition extends KickerOperator {

    @Override
    public Boolean Do() {

        KickerStop stopper = new KickerStop(new TouchSensor(SensorPort.S1));
        InThread stopListener = new InThread(stopper);
        stopListener.start();
        synchronized (kicker) {
            kicker.setSpeed(100);
            kicker.rotate(-360);
        }
        return true;
    }
}
