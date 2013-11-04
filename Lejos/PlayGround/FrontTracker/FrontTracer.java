import lejos.nxt.Button;
import lejos.nxt.Motor;
import lejos.robotics.navigation.DifferentialPilot;

/**
 * Trace  two squares, twice.  
 * @author Roger
 */
public class FrontTracer 
{
    DifferentialPilot pilot ;
    
    public static void main( String[] args)
    {
        System.out.println(" FrontTracer ");
        Button.waitForAnyPress();
        FrontTracer ft = new FrontTracer();
        ft.pilot = new DifferentialPilot(
           32.7, //  wheel diameter 
           185.0f, // distance between tracks centers
           Motor.B, Motor.C);
		   
        ft.pilot.rotate(360.0f);
    }
}