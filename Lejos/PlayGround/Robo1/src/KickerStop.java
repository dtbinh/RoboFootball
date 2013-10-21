
import lejos.nxt.TouchSensor;

public class KickerStop extends KickerOperator {

    TouchSensor sensor;

    public KickerStop(TouchSensor sensor) {
        this.sensor = sensor;
    }

    @Override
    public synchronized Boolean Do() {

        if (sensor.isPressed()) {
            if (kicker.isMoving()) {
                int prevSpeed = kicker.getSpeed();
                kicker.stop();
                kicker.setSpeed(60);
                kicker.rotate(20);
                kicker.setSpeed(prevSpeed);
                return true;
            }
        }
        return false;
    }
}