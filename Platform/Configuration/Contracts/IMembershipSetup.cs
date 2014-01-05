using Configuration.DataContracts;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace Configuration.ServiceContracts
{


    /*
  * all configuration data should be kept in DB
  * We will use local db thru Linq to sql
  */
    [ServiceContract]
    public interface IMembershipSetup
    {
        //Forbidden to use this contract before geometry is setted up



        //should send error if such team has been allready added
        [OperationContract]
        TeamMembership RegisterRobot(byte TeamId);
        
        //should send error if such team not found
        //should send erroe if robot with such id allready added
        // should send error if robot id if robot/team id is too big or wrong
        
        [OperationContract]
        PlayerData RegisterRobot(byte PlayerId, byte TeamId);
        [OperationContract]
        void UnRegisterRobot(byte PlayerId, byte TeamId);
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