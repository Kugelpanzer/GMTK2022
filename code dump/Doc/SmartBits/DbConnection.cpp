#include"DbConnection.h"


//using namespace std;
/*

void test_get(MYSQL* conn){

    MYSQL_ROW row;
    MYSQL_RES* res;
    int qstate=mysql_query(conn,"SELECT * from prva");
    if(!qstate){
        res=mysql_store_result(conn);
        while(row=mysql_fetch_row(res)){
            cout<<"\n"<<row[0]<<" "<<row[1]<<" "<<row[2];
        }
       }
}
*/
std::vector<textBlock>  GetTextBrainDB(MYSQL* conn){
    std::vector<textBlock> textBrain;

    MYSQL_ROW row;
    MYSQL_RES* res;
    int qstate=mysql_query(conn,"SELECT * from block");
    if(!qstate){
        res=mysql_store_result(conn);
        while(row=mysql_fetch_row(res)){
            textBlock currentBlock;
            currentBlock.max_syn=(int)row[1];
            currentBlock.con_num=(int)row[2];
            currentBlock.forget=(bool)row[3];

            //fetching neuron from database
            MYSQL_ROW neuron_row;
            MYSQL_RES* neuron_fetch;
            int neur_qstate=mysql_query(conn,("SELECT * from smart_bit where blockIndex="+ (std::string)row[0]).c_str());
            if(!neur_qstate){
                neuron_fetch=mysql_store_result(conn);
                while(neuron_row=mysql_fetch_row(neuron_fetch)){
                    textSBit currentNeuron;
                    currentNeuron.io_list=neuron_row[2][0];
                    currentNeuron.value=(std::string)neuron_row[3];
                    currentNeuron.out_point=atoi(neuron_row[4]);

                    MYSQL_ROW pocket_row;
                    MYSQL_RES* pocket_fetch;
                    int pocket_qstate=mysql_query(conn,("SELECT * FROM syn WHERE idSmartBit=" + (std::string)neuron_row[0]).c_str());
                    if(!pocket_qstate){
                        pocket_fetch=mysql_store_result(conn);
                        while(pocket_row=mysql_fetch_row(pocket_fetch)){
                            textPocket currentPocket;
                            bool constFlag=pocket_row[1];
                            currentPocket.io_list=pocket_row[2][0];
                            currentPocket.in_point=atoi(pocket_row[3]);
                            currentPocket.value=pocket_row[4];

                            MYSQL_ROW connection_row;
                            MYSQL_RES* connection_fetch;
                            int connection_qstate=mysql_query(conn,("SELECT * FROM connection WHERE idSyn="+(std::string)pocket_row[0]).c_str());
                            if(!connection_qstate){
                                connection_fetch=mysql_store_result(conn);
                                while(connection_row=mysql_fetch_row(connection_fetch)){
                                    currentPocket.connection.push_back(textPocket::con{atoi(row[1]),atoi(row[2])});

                                }
                            }
                            currentNeuron.syn.push_back(currentPocket);
                        }

                    }

                    currentBlock.neur_list.push_back(currentNeuron);
                }
            }
        }
       }


    return textBrain;
}



MYSQL* ConnectToDatabase(std::string databaseName,std::string username, std::string password){

    MYSQL *conn;
    conn=mysql_init(0);
    conn=mysql_real_connect(conn,GetIP().c_str(),username.c_str(),password.c_str(),databaseName.c_str(),0,NULL,0);
    if(conn){
            std::cout<<"Connected";
        }
    else{
            std::cout<<"Not connected \n";
        }
    return conn;
}

std::string GetIP(){
    std::string result="";
    std::string line;
    std::ifstream IPFile;
    int offset;
    char* search0 = "IPv4 Address. . . . . . . . . . . :";      // search pattern

    system("ipconfig > ip.txt");

    IPFile.open ("ip.txt");
    if(IPFile.is_open())
    {
       while(!IPFile.eof())
       {
           getline(IPFile,line);
           if ((offset = line.find(search0, 0)) != std::string::npos)
           {
        //   IPv4 Address. . . . . . . . . . . : 1
        //1234567890123456789012345678901234567890
           line.erase(0,39);
           result+=line;
           IPFile.close();
           }
        }
    }
    return result;
}
