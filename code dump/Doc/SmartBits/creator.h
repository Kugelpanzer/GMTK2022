#include"logicSyn.h"
#include"SmartBit.h"
//#include<string>
/*
creator is to used to create the structure(architecture) of the brain.

*/
extern std::vector<block> brain;
extern std::vector<std::string> input_list,output_list;


void block_create(int num);//creates n blocks
//void set_block(int num_block,int num_con,int num_syn,bool set_forget); //sets block_point to point to the current block
void push_allowed_block(int block_index, int block_push);//pushes  block_push to the allowed list of block point
void allowed_list(int block_index,int num,...);


smartBit set_neur(char io_list,int ch_out,char value,int const_syn_num,int syn_num); // creates a neuron and pushes it to block_point ,int ch_out is the index of chosen io_list

void parse_file(std::string fileName);

struct textPocket{
    bool nconst;
    char io_list;
    int in_point;
    std::string value="";
    struct con{
        int b;
        int n;
    };
    std::vector<con> connection;
    };

struct textSBit{
    char io_list;
    int out_point;
    std::string value="";
    std::vector<textPocket> syn;
    };

struct textBlock{
    int max_syn;
    int con_num;
    bool forget;
    std::vector<int> allowed;
    std::vector<textSBit> neur_list;
    };

std::vector<std::string> str_split(std::string str ,std::string delimiter);




