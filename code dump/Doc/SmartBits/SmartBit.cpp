#include"SmartBit.h"

/*trash
std::cout<<"\n"<<*it<<" , "<<"\n"<<**it;

*/
void smartBit::forget_exe(){
    if((curSyn>0)&&(forget==true)){
        syn.pop_back();
        //add destructor to free memory
    }
}

bool smartBit::active_neur(){
std::list<pocket>::iterator pomIt;
bool ret=false;
//int i= 0;
    std::cout<<syn.size()<<"\n";
	for (std::list<pocket>::iterator nit=syn.begin(); nit != syn.end(); ++nit) { // nit iterator pointing to pockets
        pomIt=nit;
            /*std::cout<<"i: "<<i;
            i++;*/
	if(nit->check_active() == true){
            preActive=true;
            std::cout<<nit->id<<"\n"; //jsut for testing


		if(++nit!=syn.end()){

            if(nit!=syn.begin()){

                syn.splice(syn.begin(),syn,pomIt);
                nit--;

                }
			ret=true;

			}
		else {
            --nit;
			syn.splice(syn.begin(),syn,pomIt);

			return true;
			}
		}
	}
    for (std::list<pocket>::iterator nit=constSyn.begin(); nit != constSyn.end(); ++nit){
        if(nit->check_active() == true) {
                preActive=true;
                return true;
        }
    }
    if(ret==false)  forget_exe();
	return ret;
}

void block::new_connection(smartBit &a){
    pocket newCon;
    int curCon=0; // current number of connections has to be = maxCon
    for(std::vector<block*>::iterator biter=allowedBlockes.begin(); (biter != allowedBlockes.end()) &&(curCon<maxCon+1); ++biter)
        for(std::vector<smartBit*>::iterator smit = (*biter)->activeNeur.begin(); smit != (*biter)->activeNeur.end(); ++smit){
            if(&(**smit)!=&a)
                /*
                *SHOULD CHOOSE RANDOM neuron from list of activated neurons but never the same
                *Like deck of cards
                */
                /*{
                for(std::list<pocket>::iterator pit=(*smit)->syn.begin(); pit!=(*smit)->syn.end(); ++pit){
                        if(pit->active==false)  break;
                        if(curCon==maxCon)  break;
                        else{
                            newCon.connection.push_back(&(pit->active));
                            curCon++;
                            //std::cout<<pit->active;
                            }
                        }
                for(std::list<pocket>::iterator pit=(*smit)->constSyn.begin(); pit!=(*smit)->constSyn.end(); ++pit){
                        if(pit->active==false){
                                break;
                            }
                        else{
                            newCon.connection.push_back(&(pit->active));
                            //std::cout<<pit->active;
                            curCon++;
                            //std::cout<<"ubaceno";
                            }
                        }
                }*/
                 if((*smit)->active==false)  break;
                        if(curCon==maxCon)  break;
                        else{
                            newCon.connection.push_back(&((*smit)->active));
                            curCon++;
                            //std::cout<<pit->active;
                            }

            }

    if(curCon==maxCon){
        std::cout<<"ub ";
        if(a.curSyn>=maxSyn){
            a.syn.pop_back();
            //add destructor to free memory

            }
        else if(a.curSyn<maxSyn){
            a.syn.push_back(newCon);
            a.curSyn++;
            }

    }

}
void block::force_connection(){


}


void block::allow_block(block* b){
    allowedBlockes.push_back(b);
}
void block::allow_blockes(std::vector<block*> blockes){
    for(std::vector<block*>::iterator b= blockes.begin(); b!= blockes.end(); ++b)
        allowedBlockes.push_back(*b);
    }
void block::pass(){
    bool flag=false; // checks if neuron is alrady in activeNeur list
    activeNeur.clear();
    for(std::vector<smartBit>::iterator smit = neur.begin(); smit != neur.end(); ++smit){
        flag=false;
        /*for(std::list<pocket>::iterator pit=smit->syn.begin(); pit!=smit->syn.end(); ++pit){
             pit->active=pit->preActive;
             if((pit->preActive==true)&&(flag==false)){
                activeNeur.push_front(&(*smit));
                flag=true;
             }
             pit->preActive=false;void allowed_block();
         }*/
        smit->active=smit->preActive;
            if((smit->preActive==true)&&(flag==false)){
                activeNeur.push_back(&(*smit));
                flag=true;
            }
        smit->preActive=false;
     }

    for(std::vector<smartBit>::iterator smit = neur.begin(); smit != neur.end(); ++smit){
        if(smit->active_neur()==true){
            std::cout<<smit->idb;
            if(smit->outPoint!=NULL)
                *(smit->outPoint)=smit->outValue;
            new_connection(*smit);
            }
        }

}
void block::push_neur(smartBit &neuron){
    neur.push_back(neuron);
}

void block::set_forget(bool forget_val){
        for(std::vector<smartBit>::iterator smit = neur.begin(); smit != neur.end(); ++smit){
        (*smit).forget=forget_val;
        }
}


/*int main(){

	return 1;
}*/
