public class KickerKick extends KickerOperator{

    @Override
    public Boolean Do() {
        if (!kicker.isMoving()) {
                kicker.setSpeed(360);
                kicker.rotate(60);
                return true;
            }
        return false;
    }
}
