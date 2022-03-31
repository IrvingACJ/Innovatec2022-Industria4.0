from os import getenv
import pymssql

class SQL:
    def __init__(self, name):
        self.conn = pymssql.connect(
            host='localhost',
            server=name, 
            #port='1433', 
            user='Python', password='Ted123', 
            database='SistemaI4'
        ) 
    def Delete(self, table, where_key, value):    
            cursor = self.conn.cursor()
            cursor.execute("DELETE FROM "+table+" WHERE "+where_key+" = "+value)
            self.conn.commit()
            self.conn.close()        

    def Insert(self, table, keys, values):
            strcmd = "INSERT INTO "+table+"  ("+', '.join(keys)+") VALUES ("+', '.join(values)+")"
            cursor = self.conn.cursor()
            cursor.execute(strcmd)
            self.conn.commit()
            self.conn.close()        

    def Select(self, table, select_keys, where_key, value):    
            strcmd = "SELECT "+', '.join(select_keys)+" FROM "+table+" WHERE "+where_key+" = "+value
            cursor = self.conn.cursor()
            cursor.execute(strcmd)
            row = cursor.fetchone()
            return row;

    def Update(self, table, dataset, where_key, value):    
            strcmd = "UPDATE "+table+" SET "+dataset+" WHERE "+where_key+" = "+value
            cursor = self.conn.cursor()
            cursor.execute(strcmd)
            self.conn.commit()
            self.conn.close()        
