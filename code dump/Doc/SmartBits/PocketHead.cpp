#include"PocketHead.h"


bool pocket::check_active(){  // check if connection memPoint is not pointing to anything
    if((memPoint!=NULL)&&(staticMem==*memPoint)){
        //preActive=true;
        return true;
	}
	else if(!connection.empty()) {
		for (std::vector<bool*>::iterator it=connection.begin(); it != connection.end(); ++it){
			if((**it) == false){
				//preActive=false;
				return false;

			}
			else if ((**it)==true){

				if(*it==connection.back()){
					//preActive=true;
					return true;
				}
			}


		}
	}
	else {
		return false;
	}
}
