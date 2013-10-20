
import lejos.nxt.Button;
import lejos.nxt.Motor;

public class Player {

    KickerOperator kick = new KickerKick();
    KickerOperator toPosition = new KickerToPosition();

    public Player() {
        KickerOperator.kicker = Motor.A;
        toPosition.Do();

    }

    public static void main(String[] args) throws InterruptedException {

        System.out.println(" Robo 1 ");
        System.out.println(" Press Button To Start ");
        Button.waitForAnyPress();

        Player player = new Player();
        System.out.println(" Started ");

        System.out.println(" kick 1 ");
        player.KickSomething();
        Thread.sleep(1000);
        System.out.println(" kick 2 ");
        player.KickSomething();

        System.out.println(" wait to quit ");
        Button.waitForAnyPress();
    }

    private void KickSomething() {
        kick.Do();
        toPosition.Do();
    }

    public void GoTo(int x, int y) {
    }
}