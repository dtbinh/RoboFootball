
import lejos.nxt.Motor;
import lejos.robotics.navigation.DifferentialPilot;

public abstract class TrackOperator extends Operator{
   DifferentialPilot pilot = new DifferentialPilot(
           32.7, //  wheel Diameter //  
           190.0f, // distance between tracks centers 
                   // Adjusted for rag flor
                   // It depends on surface type becouse of creeping
           Motor.B, Motor.C);
   public abstract void Terminate();
}
