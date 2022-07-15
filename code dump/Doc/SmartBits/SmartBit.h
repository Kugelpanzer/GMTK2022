#include"PocketHead.h"
#include<list>
//#include<random>



class smartBit{
	public:
    smartBit(){
        syn.clear();
    }

    smartBit(std::string* outPointer,std::string value){
        outPoint= outPointer;
        outValue=value;
    }
    int idb=0;
    bool active=false,preActive=false;
    int curSyn=0; // how much synapses neuron has right now
    std::string *outPoint=NULL,outValue=""; //outpint outputs out value to the given address
    std::list<pocket> constSyn;
	std::list<pocket> syn;
	bool active_neur(); // checks all the syn if they are active   they are moved to first place on the list, if its activated returns true
	bool forget=false; // if forget = true then ecery time neur doesnt activate forget_exe is called
    void forget_exe();
};

class block{
	public:
    block(){
	    }
    block(std::vector<smartBit> neurons,int synaps,int connection, bool forget_val)
    {
        maxCon=connection;
        maxSyn=synaps;
        neur=neurons;
        set_forget(forget_val);
        //allowedBlockes=blockes;

      //  activeNeur=neurons;
        //allowedBlockes=blockes;
    }
    block(int synaps,int connection, bool forget_val){
        maxCon=connection;
        maxSyn=synaps;
        set_forget(forget_val);
    }
    int maxCon=3; // number of connection = maxCon (cant have more or less!)
    int maxSyn=15; //can have up to maxSyn if it has max syn it deletes last one and adds new connection on the first place
	std::vector<smartBit> neur;
	std::vector<smartBit*> activeNeur;//list that contains active neur of the block
	std::vector<block*> allowedBlockes; // allowed blockes to check for activating neur
	void allow_block(block* b);
	void allow_blockes(std::vector<block*> blockes); //pushes addres of the block that is suppose to be checked
    void push_neur(smartBit &neuron);
	void set_forget(bool ferget_val);
	void force_connection(); //creates one connection every time block is passed
	void new_connection(smartBit &a); //(a is a smart bit that should get new connection) if neuron active returns true it activates this function, this function goes thrue all possible blocks and checks if its posible to make new connections (pocket)
	void pass(); // passes all neurons in block, if neuron activates calls newConnection fucntion, sets all activeted neurons in activeNeur list, changes all connection active=preActive,
};



