
import lejos.nxt.Motor;
import lejos.robotics.navigation.DifferentialPilot;

public abstract class TrackOperator extends Operator{
   DifferentialPilot pilot = new DifferentialPilot(2.25f, 5.5f, Motor.B, Motor.C);
}
