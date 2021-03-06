using Configuration.DataContracts;
using System.ServiceModel;

namespace Configuration.ServiceContracts
{
    /*
  * all configuration data should be kept in DB
  * We will use local db thru Linq to sql
  */

    /*
     * User could add or delete data for team but if will be hit team confirm all data will be kept to db
     * And user could not change this data until game ends
     * 
     */
    [ServiceContract]
    public interface IMembershipSetup
    {
        //Forbidden to use this contract before geometry is setted up

        //should send error if such team has been allready added
        [OperationContract]
        TeamMembership RegisterTeam(byte TeamId);
        
        //should send error if such team not found
        //should send erroe if robot with such id allready added
        //should send error if robot id if robot/team id is too big or wrong
        
        [OperationContract]
        PlayerData RegisterRobot(byte PlayerId, byte TeamId);

        
        [OperationContract]
        void UnRegisterRobot(byte PlayerId, byte TeamId);

        //Commits all changes with team.
        //After this team will be ready for game.
        [OperationContract]
        void ConfirmTeam(byte TeamId);
    }


    [ServiceContract]
    public interface IMembershipManager
    {
        [OperationContract]
        GameMembership GetMembership();

        //should send error if there is no shuch team
        [OperationContract]
        TeamMembership GetTeam(byte TeamId);

        //should send error if there is no shuch team or player
        [OperationContract]
        PlayerData GetPalyer(byte PlayerId,byte TeamId);
    }
}