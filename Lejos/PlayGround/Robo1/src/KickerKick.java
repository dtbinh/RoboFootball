
public class KickerKick extends KickerOperator {

    @Override
    public synchronized Boolean Do() {
//        if (!kicker.isMoving()) {
            System.out.println(" kick! ");
            kicker.setSpeed(1200);
            kicker.rotate(90);
            return true;
//        }
//        return false;
    }
}
