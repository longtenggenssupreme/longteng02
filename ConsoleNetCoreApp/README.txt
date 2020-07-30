服务端
LINUX CentOS 7 Docker 安装MongoDB的步骤

[lj@localhost ~]$ sudo docker search mongo
[lj@localhost ~]$ sudo docker pull mongo: latest
[lj@localhost ~]$ sudo docker images
[lj@localhost ~]$ sudo docker run --name mymongodb -p 27017:27017 -itd mongo
[lj@localhost ~]$ sudo docker ps
[lj@localhost ~]$ sudo docker ps | grep mymongodb
[lj@localhost ~]$ sudo docker rm mymongodb -f
[lj@localhost ~]$ sudo docker run --name mymongodb -p 27017:27017 -itd mongo --auth    --auth 表示用户密码验证
[lj@localhost ~]$ sudo docker exec -it mymongodb mongo admin
> db.createUser({user:'admin',pwd:'123456',roles:[{role:'userAdminAnyDatabase',db:'admin'}]});创建用户admin和密码123456以及数据库admin和角色userAdminAnyDatabase
Successfully added user: {
	"user" : "admin",
	"roles" : [
		{
			"role" : "userAdminAnyDatabase",
			"db" : "admin"
		}
	]
}
> db.auth('admin','123456')
1
> exit
[lj@localhost ~]$ sudo docker exec -it  mymongodb mongo admin
> show dbs
> db.auth('admin','123456')
1
> show dbs
admin   0.000GB
config  0.000GB
local   0.000GB
> db.createUser({user:"lj",pwd:"123456",roles:[{role:"root",db:"admin"}]})  创建用户lj和密码123456以及数据库admin和角色root
Successfully added user: {
	"user" : "lj",
	"roles" : [
		{
			"role" : "root",
			"db" : "admin"
		}
	]
}
> db.auth('lj','123456')
1
> show dbs
admin   0.000GB
config  0.000GB
local   0.000GB
> exit


附:添加用户时各个角色对应权限

1.数据库用户角色：read、readWrite;
2.数据库管理角色：dbAdmin、dbOwner、userAdmin；
3.集群管理角色：clusterAdmin、clusterManager、clusterMonitor、hostManager；
4.备份恢复角色：backup、restore
5.所有数据库角色：readAnyDatabase、readWriteAnyDatabase、userAdminAnyDatabase、dbAdminAnyDatabase
6.超级用户角色：root