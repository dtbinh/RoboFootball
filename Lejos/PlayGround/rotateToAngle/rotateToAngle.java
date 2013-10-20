import lejos.nxt.Button;
import lejos.nxt.LCD;
import lejos.util.Delay;
import lejos.nxt.Motor;
 
public class rotateToAngle 
{
	public static void main(String[] args) 
    {
		LCD.drawString("Turn IT!", 0, 0);
		Button.waitForAnyPress();
		LCD.drawString("45", 0, 0);		
        Motor.B.rotate(45);
        LCD.drawInt(Motor.B.getTachoCount(),0,1);
        Button.waitForAnyPress();
		LCD.drawString("-45", 0, 0);		
        Motor.B.rotate(-45);
        LCD.drawInt(Motor.B.getTachoCount(),0,1);
        Button.waitForAnyPress();
    }
 }