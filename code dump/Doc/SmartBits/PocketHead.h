#include<iostream>
#include <vector>
#pragma once

class pocket{
	public:
    static int current_id; //this int is only for tsting
    int id;
    pocket(){
    connection.clear();
    id=current_id;
    current_id++;
    }
    pocket(std::string* memoryPointer, std::string memoryWriteValue,std::vector<bool*> pocketConnection){
        memPoint=memoryPointer;
        staticMem=memoryWriteValue;
        connection=pocketConnection;
    }
    pocket(std::string* memoryPointer, std::string memoryWriteValue){
        memPoint=memoryPointer;
        staticMem=memoryWriteValue;
    }


	//bool preActive=false,active=false;
	std::string *memPoint=NULL,staticMem=""; // memory: points to character type in memory,staticMem: conatains what character activates pocket
	std::vector<bool*> connection;

	bool check_active();		// (if memory is not NULL)first checks if memory is equal to staticMem if that is true it sets preActive to true else -> checks all connection if they are all activated (active = true) preActive is set to true (preferably its a recursive function)

};
