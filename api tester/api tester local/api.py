#importing libs
print("""______________________________________
         LIBS LOADING...
""")
from flask import Flask, make_response, jsonify, request
from random import choice
from string import ascii_uppercase
import ast
import mysql.connector
print("""______________________________________
         DONE
""")
print("""______________________________________
         CONNECTING TO MYSQL...
""")

#mysql
binary_data = bytes([51])
binary = binary_data.decode('utf-8')
mydb = mysql.connector.connect(
  host="localhost",
  user="root",
  passwd=binary
  #passwd = "170799ssS"
)
print("""______________________________________
         DONE
______________________________________
         Running API...
______________________________________
""")

#flask settings
app = Flask(__name__)
mycursor = mydb.cursor()
#404 error handler   
@app.errorhandler(404)
def not_found(error):
    return make_response(jsonify({'ERROR':'Bad idea'}),404)

#401 invalid auth
def invalid_auth():
    auth_resp = make_response(jsonify({'status':'false', 'message': 'Invalid authorization data'}))
    auth_resp.status = 'Invalid authorization data'
    auth_resp.status_code = 401
    return auth_resp

def get_group(token):
    mydb.commit()
    mycursor.execute("use grps")
    mycursor.execute("show tables")
    myresult = mycursor.fetchall()
    for x in myresult:
        n = 0
        x = x[n]
        mycursor.execute("SELECT * FROM `{0}` WHERE token = '{1}'".format(x, token))
        user_available = mycursor.fetchall()
        if len(user_available) != 0:
            group = x
            return group
    n += 1
#get available tests
def av_tests(group):
    mydb.commit()
    mycursor.execute("use tests")
    mycursor.execute("SELECT tests FROM available_test WHERE available_groups LIKE '{0}'".format(group))
    result = mycursor.fetchall()
    #result = result[3:len(result)-4]
    return result   

#handler for auth(POST method)
@app.route('/auth',methods = ['POST'])
def auth():
    mydb.commit()
    try:
        mycursor.execute("use grps")
#geting data from user, decode
        data = request.data
        data = data.decode("utf-8")
        data = data.replace('"',"'")      
        data = dict(ast.literal_eval(data))
#geting values from data
        group = data.get('group')
        name = data.get('name')
        password = data.get('password')
#operations with db
        mycursor.execute("SELECT * FROM `{0}` WHERE name = '{1}'".format(group, name))
        myresult = mycursor.fetchall()
    except:
        return invalid_auth()
    if len(myresult) == 0:
        return invalid_auth()
    else:
        mycursor.execute("SELECT token FROM `{0}` WHERE name = '{1}';".format(group, name))
        check_tok = mycursor.fetchall()
        token = None
        if check_tok[0][0] == None:
            token = ''.join(choice(ascii_uppercase) for i in range(32)) #generating token for user
            mycursor.execute("UPDATE `{0}` SET token='{1}' WHERE name = '{2}';".format(group, token, name))
            mydb.commit()
        else:
            token = check_tok[0][0]
        auth_resp = make_response(jsonify({'token': token}))
        auth_resp.status = 'Successful authorization'
        auth_resp.status_code = 200
        return auth_resp
           
#handler for get (GET method)
@app.route('/test_list',methods = ['GET'])
def get_test_list():
    mydb.commit()
    if not request.args or not 'token' in request.args:
        return invalid_auth()
    else:
        grp = None
        grp = get_group(request.args['token'])
        if grp == None:
            return invalid_auth()
        tests = av_tests(grp)
        if len(tests) == 0:
            auth_resp = make_response(jsonify({'tests_list': 'нет тестов'}))
            auth_resp.status = 'Successful authorization'
            auth_resp.status_code = 200
            return auth_resp
        auth_resp = make_response(jsonify({'tests_list':tests}))
        auth_resp.status = 'Successful authorization'
        auth_resp.status_code = 200
        return auth_resp
    
@app.route('/test_timer',methods = ['POST'])
def test_timer():
    mydb.commit()
    data = request.data
    data = data.decode("utf-8")
    data = data.replace('"',"'")      
    data = dict(ast.literal_eval(data))
    token = data.get('token')
    mycursor.execute("use tests")
    mycursor.execute("SELECT time FROM testresult WHERE token = '{0}' and ended = '0'".format(token))
    old_time = mycursor.fetchall()[0][0]
    new_time = int(old_time) - 1
    mycursor.execute("UPDATE testresult SET time = '{1}' WHERE token = '{0}' and ended = '0'".format(token,new_time))
    mydb.commit()
    auth_resp = make_response(jsonify({'time':new_time}))
    auth_resp.status = 'Successful authorization'
    auth_resp.status_code = 200
    return auth_resp
    
@app.route('/get_test',methods = ['GET'])
def get_test():
    mydb.commit()
    if not request.args or not 'token' or not 'test' in request.args:
        return invalid_auth()
    else:
        grp = None
        grp = get_group(request.args.get('token'))
        if grp != None:
            if request.args.get('test') in str(av_tests(grp)):
                mycursor.execute("use tests")
                mycursor.execute("SELECT question FROM `{0}`".format(request.args.get('test')))
                qst = mycursor.fetchall()
                mycursor.execute("SELECT answers FROM `{0}`".format(request.args.get('test')))
                ans = mycursor.fetchall()
                mycursor.execute("SELECT timer FROM `testtimer` WHERE test = '{0}' ".format(request.args.get('test')))
                av_time = mycursor.fetchall()[0][0]
                mycursor.execute("SELECT * FROM testresult WHERE token = '{0}' and test = '{1}'".format(request.args.get('token'),request.args.get('test')))
                avt = mycursor.fetchall()
                clear_list = ''.join('3,' for i in range(len(qst)))
                clear_list = clear_list[0:len(clear_list)-1]
                tpe = clear_list.split(',')
                tpe = list(map(int,tpe))
                ended = 0
                if len(avt) == 0:
                    mycursor.execute("INSERT INTO testresult (token,test,result,ended, time) VALUES ('{0}','{1}','{2}','{3}','{4}')".format(request.args.get('token'),request.args.get('test'),clear_list,0,av_time))
                    mydb.commit()
                else:
                    mycursor.execute("SELECT time FROM testresult WHERE token = '{0}' and test = '{1}'".format(request.args.get('token'),request.args.get('test')))
                    av_time = mycursor.fetchall()[0][0]
                    mycursor.execute("SELECT result FROM testresult WHERE token = '{0}' and test = '{1}'".format(request.args.get('token'),request.args.get('test')))
                    tpe = mycursor.fetchall()[0][0]
                    tpe = tpe.split(',')
                    tpe = list(map(int,tpe))
                    mycursor.execute("select ended from testresult where token = '{0}' and test = '{1}'".format(request.args.get('token'),request.args.get('test')))
                    ended = mycursor.fetchall()[0][0]
                auth_resp = make_response(jsonify({'quetsions':qst,'answers':ans,'usr_answs':tpe,'time':av_time,'ended':ended}))
                auth_resp.status = 'Successful authorization'
                auth_resp.status_code = 200
                return auth_resp
        else:
            return invalid_auth()

@app.route('/send_answ',methods = ['POST'])
def send_answ():
    mydb.commit()
    data = request.data
    data = data.decode("utf-8")
    data = data.replace('"',"'")      
    data = dict(ast.literal_eval(data))
    token = data.get('token')
    qust = data.get('qust')
    answ = data.get('answ')
    mycursor.execute("use tests")
    mycursor.execute("select test from testresult where token = '{0}' and ended = '0'".format(token))
    test = mycursor.fetchall()[0][0]
    mycursor.execute("use tests")
    mycursor.execute("SELECT good_answer FROM `{0}` WHERE id = '{1}'".format(test,qust))
    good_answ = mycursor.fetchall()
    print(answ,good_answ[0][0])
    if answ == good_answ[0][0]:
        print('true')
        temp_list = "0"
        qwer = ""
        mycursor.execute("select result from testresult where token = '{0}'".format(token))
        temp_list = mycursor.fetchall()[0][0]
        temp_list = temp_list.split(',')
        temp_list[int(qust) - 1] = 1
        qwer = qwer.join((str(x)+',') for x in temp_list)
        qwer = qwer[0:len(qwer)-1]
        mycursor.execute("use tests")
        mycursor.execute("update testresult set result = '{1}' where token = '{0}'".format(token,qwer))
        mydb.commit()
        auth_resp = make_response(jsonify({'answ':'1'}))
    else:
        print('false')
        temp_list = "0"
        qwer = ""
        mycursor.execute("select result from testresult where token = '{0}'".format(token))
        temp_list = mycursor.fetchall()[0][0]
        temp_list = temp_list.split(',')
        temp_list[int(qust) - 1] = 0
        qwer = qwer.join((str(x)+',') for x in temp_list)
        qwer = qwer[0:len(qwer)-1]
        mycursor.execute("use tests")
        mycursor.execute("update testresult set result = '{1}' where token = '{0}'".format(token,qwer))
        mydb.commit()
        auth_resp = make_response(jsonify({'answ':'0'}))
    auth_resp.status = 'Successful authorization'
    auth_resp.status_code = 200
    return auth_resp

@app.route('/end_test',methods = ['POST'])
def end_test():
    mydb.commit()
    data = request.data
    data = data.decode("utf-8")
    data = data.replace('"',"'")      
    data = dict(ast.literal_eval(data))
    token = data.get('token')
    try:
        green = 0
        red = 0
        ocenka = 2
        mycursor.execute("use tests")
        mycursor.execute("select result from testresult where token = '{0}'".format(token))
        temp_list = mycursor.fetchall()[0][0]
        temp_list = temp_list.split(',')
        res = len(temp_list)/5
        for i in temp_list:
            if i == '1':
                green+=1
            else:
                red+=1
        if green >= res *2:
            ocenka = 3
        if green >= res *3:
            ocenka = 4
        if green >= res*4:
            ocenka = 5
        mycursor.execute("update testresult set ended = '1' where token = '{0}'".format(token))
        mycursor.execute("update testresult set ocenka = '{1}' where token = '{0}'".format(token,ocenka))
        mydb.commit()
        auth_resp = make_response(jsonify({'result':'True'}))
    except:
        auth_resp = make_response(jsonify({'result':'False'}))
    auth_resp.status = 'Successful authorization'
    auth_resp.status_code = 200
    return auth_resp

@app.route('/get_result',methods = ['GET'])
def get_result():
    return "ok"
if __name__ == '__main__':
    app.config['JSON_AS_ASCII'] = False
    app.run(host="127.0.0.1", port=int("8080"), debug=True)
