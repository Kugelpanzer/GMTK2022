#include"creator.h"
#include <stdarg.h>
#include<fstream>
#include<string>
#include <algorithm>

std::vector<block> brain;
std::vector<std::string> input_list,output_list;

void block_create(int n){
    for(int i=0;i<n;i++){
        block bb;
        brain.push_back(bb);
    }

}

void push_allowed_block(int block_index, int block_push){
    brain[block_index].allowedBlockes.push_back(&brain[block_push]);
}

void allowed_list(int block_index,int num,...){

    va_list arguments;                     // A place to store the list of arguments

    va_start ( arguments, num );           // Initializing arguments to store all values after num
    for ( int x = 0; x < num; x++ )        // Loop until all numbers are added
        push_allowed_block(block_index,va_arg ( arguments, int ));
    va_end ( arguments );                  // Cleans up the list

  }


smartBit set_nuer(char io_list,int st_out,std::string value){

    if(io_list=='i' && st_out<input_list.size())
        return smartBit(&input_list[st_out],value);
    else if(io_list=='o' && st_out<output_list.size())
        return smartBit(&output_list[st_out],value);
}
pocket set_pocket(char io_list,int st_in,std::string value){
    if(io_list=='i' && st_in<input_list.size())
        return pocket(&input_list[st_in],value);
    else if(io_list=='o' && st_in<output_list.size())
        return pocket(&output_list[st_in],value);
    else if(io_list=='n')
        return pocket();
}
std::vector<std::string> str_split(std::string str ,std::string delimiter){

    int pos =0;
    std::string token;
    std::vector<std::string> ret;
    while((pos = str.find(delimiter)) != std::string::npos) {
        token = str.substr(0, pos);
        ret.push_back(token);
        str.erase(0, pos + delimiter.length());
    }
    ret.push_back(str);

    return ret;
}



void FromTextToBrain(std::vector<textBlock> textBrain){

    for(int i=0; i < textBrain.size();i++ ){

        brain.push_back(block(textBrain[i].max_syn,textBrain[i].con_num,textBrain[i].forget));

        for(int j=0; j< textBrain[i].allowed.size();j++){

            push_allowed_block(i,j);
        }
        for(int j=0;j<textBrain[i].neur_list.size();j++){
            textSBit textSb=textBrain[i].neur_list[j];
            smartBit sb=set_nuer(textSb.io_list,textSb.out_point,textSb.value);


            for(int k=0;k<textBrain[i].neur_list[j].syn.size();k++){
                textPocket textP=textBrain[i].neur_list[j].syn[k];
                //(char* memoryPointer, char memoryWriteValue,std::vector<bool*> pocketConnection)
                pocket currSyn=set_pocket(textP.io_list,textP.in_point,textP.value);
                //CONNECTIONS

                if(textP.nconst){
                    sb.constSyn.push_back(currSyn);
                }else{
                    sb.syn.push_back(currSyn);
                }
            }


            brain[i].push_neur(sb);
        }

    }
         for(int i=0; i < textBrain.size();i++ )
            for(int j=0; j< textBrain[i].allowed.size();j++)
                for(int j=0;j<textBrain[i].neur_list.size();j++)
                    for(int k=0;k<textBrain[i].neur_list[j].syn.size();k++)
                        for(int o=0; o<textBrain[i].neur_list[j].syn[k].connection.size();o++){
                            textPocket textP=textBrain[i].neur_list[j].syn[k];
                            std::vector<bool*> con;
                            con.push_back(&(brain[textP.connection[o].b].neur[textP.connection[o].n].active));
                            }

}

void parse_file(std::string str){

    /*
    example-file:
    first two lines set size of  input output list
        50
        30
        5,3,T:10,15,1,4,3
        [
            i,5,a:(c,i,5,a:{4,2},{5,5},{10,5}),(n:{2,1},{2,5},{50,5})
            i,5,a:(c:{4,2},{5,5},{10,5}),(n:{2,1},{2,5},{50,5})
        ]
    */
    std::vector<textBlock> textBrain;
    std::string line;
    std::ifstream myfile(str+".txt");
    int line_counter=0;
    //textBrain.push_back(new textBlock);
    bool bracket_flag =false;
    if (myfile.is_open())
    {
        while ( getline (myfile,line) )
            {
            //read line by line
            //remove_if(line.begin(), line.end(), isspace);
            line.erase(remove_if(line.begin(), line.end(), isspace), line.end());
            std::transform(line.begin(), line.end(), line.begin(),[](unsigned char c){ return std::tolower(c); });
            //std::cout <<line;
            if(line_counter==0){
                for(int i=0;i <std::stoi(line);i++)
                    input_list.push_back(NULL);
                line_counter++;
            }else if(line_counter==1){
                for(int i=0;i <std::stoi(line);i++)
                    output_list.push_back(NULL);
                line_counter++;
            }
            else{
                if(line=="["){
                   // textBrain.back()
                    bracket_flag=true;
                }
                else if(line=="]"){

                    bracket_flag=false;
                }
                else {
                        if(!bracket_flag){
                            // INSERTING BLOCK --------------------------------------------------
                            textBlock pom;

                            std::vector<std::string> get_split=str_split(line,":");
                            std::string specs=get_split[0];
                            std::string allowed_blocks=get_split[1];

                            std::vector<std::string>spec_list=str_split(specs,",");
                            pom.max_syn=std::stoi(spec_list[0]);
                            pom.con_num=std::stoi(spec_list[1]);
                            if(spec_list[2]=="t"){
                                pom.forget=true;
                            }
                            else if(spec_list[2]=="f"){
                                pom.forget=false;
                            }

                            std::vector<std::string> allowed=str_split(allowed_blocks,",");
                            for(int i=0; i<allowed.size();i++){
                               pom.allowed.push_back(std::stoi(allowed[i]));
                            }

                            //std::cout<<"..."<<pom.forget<<"...";

                            textBrain.push_back(pom);

                        }
                        else{
                        //SMART BIT LIST FOR BLOCK ------------------------------------------------
                            textSBit pom;
                            std::vector<std::string> get_split=str_split(line,":(");
                            std::string specs=get_split[0];
                            std::string conStr=get_split[1];

                            std::vector<std::string>spec_list=str_split(specs,",");
                            pom.io_list=spec_list[0].front();
                            pom.out_point=std::stoi(spec_list[1]);
                            pom.value=spec_list[2]/*[0]*/;

                            std::vector<std::string> split_con=str_split(conStr,"),(");
                            split_con.back().pop_back();
                            //split_con[0].erase(0,1);
                           // line_counter++;   //<---- MOGUCA GRESKA

                            //POCKET IS ADDED TO SBIT ----------------------------------------
                            for(int i=0; i<split_con.size();i++){
                                textPocket pomPocket;
                                std::string nconst;
                                std::vector<std::string> split=str_split(split_con[i],":");
                                std::string specs_con=split[0];
                                std::string connection_str=split[1];

                                //std::cout<< "\nbum "<<specs_con<<" bum\n";
                                //std::cout<< "\nbum "<<split_con[i]<<" bum\n";
                                std::vector<std::string> syn_spec_list=str_split(specs_con,",");
                                if(syn_spec_list.size()==1){
                                    nconst=syn_spec_list[0];
                                    pomPocket.io_list='n';
                                }else{
                                    nconst=syn_spec_list[0];
                                    pomPocket.io_list=syn_spec_list[1][0];
                                    pomPocket.in_point=std::stoi(syn_spec_list[2]);
                                    pomPocket.value=syn_spec_list[3]/*[0]*/;
                                }
                                /*for(int w=0;w<syn_spec_list.size();w++){
                                std::cout<<"\n..."<<syn_spec_list[w]<<"...\n";
                                }*/
                                /*nconst=split_con[i].substr(0,2);
                                nconst.pop_back();*/

                                if(nconst=="n"){
                                    pomPocket.nconst=false;
                                }
                                else if(nconst=="c"){
                                    pomPocket.nconst=true;
                                }
                                //split_con[i].erase(0,2);

                                std::vector<std::string> con_str=str_split(connection_str,"},{");
                                con_str.back().pop_back();
                                con_str[0].erase(0,1);


                                for( int j=0; j<con_str.size(); j++){
                                    //std::cout<< "\n...."<<con_str[j]<<"....\n";
                                    int b=std::stoi(str_split(con_str[j],",")[0]);
                                    int n= std::stoi(str_split(con_str[j],",")[1]);
                                    pomPocket.connection.push_back(textPocket::con{b,n});
                                    }
                                /*for( int j=0; j<con_str.size(); j++)
                                    std::cout<< "\n"<<pomPocket.connection[j].n<<"\n";*/
                                pom.syn.push_back(pomPocket);
                            }

                            //p.connection.push_back(textPocket::con{2,3});
                            /*
                            for(int i=0; i<split_con.size();i++){
                            std::cout<<"\n..."<<split_con[i]<<"...\n";}
                                 for(int i=0;i <std::stoi(line);i++)
                    input_list.push_back('0');       */

                            //std::cout<<"..."<<pom.io_list<<"...";std::cout<<"..."<<pom.forget<<"...";

                            textBrain.back().neur_list.push_back(pom);
                        }
                }



            }
        }



    myfile.close();
    }
    else std::cout << "Unable to open file";
    std::cout<<textBrain.size();
    //FromTextToBrain(textBrain);
}



