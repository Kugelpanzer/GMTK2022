#include"DbConnection.h"
#include <winsock.h>
#include<mysql.h>
#include<fstream>
#include<windows.h>
#include <sstream>
#include<random>

using namespace std;

void test_get(MYSQL* conn){

    MYSQL_ROW row;
    MYSQL_RES* res;
    int qstate=mysql_query(conn,"SELECT * from prva");
    int br=0;
    if(!qstate){
        res=mysql_store_result(conn);
        while(row=mysql_fetch_row(res)){
            cout<<"\n"<<row[0]<<" "<<row[1]<<" "<<row[2];
            br+=atoi(row[0]);
        }
        cout<<br;
       }
}
void test_input(MYSQL* conn,string table,int id, string ime,string prezime){
    stringstream input;
    input<<"INSERT INTO "<<table<<"(id,ime,prezime) VALUES("<<id<<",'"<<ime<<"','"<<prezime<<"')";
    int qstate=mysql_query(conn,input.str().c_str());

    if(qstate==0) cout <<"\n success";
    else cout<<"\n failed";
}


int pocket::current_id=0;
int main(){


/*for(int i=0;i<10;i++){
 cout<<randominit();
*/



MYSQL* conn=ConnectToDatabase("test","admin","admin");

//test_input(conn,"prva",15,"laza","lazic");
test_get(conn);
	return 0;

}


