from tkinter import * 
from SqlCon import SQL
import uuid
#import RPi.GPIO as GPIO  # import GPIO
#from hx711 import HX711  # import the class HX711

class App:
    
    def __init__(self, master) -> None:
        #CODIGO NUEVO
        self.SQL_Action= SQL("IRVANDOLAP\SQLEXPRESS");
        #
        self.master = master
        self.MAC= hex(uuid.getnode())
        #Label(self.master, text="I have default font-size").pack(pady=20)
        Button(
            self.master,
            text="Iniciar secuencia de calibracion",
            font=("Arial", 18),
            command= self.Click_Calibration).pack()
        
    def Click_Calibration(self):
        self.DOUT = StringVar()
        self.SCK = StringVar()
        Label(
            self.master,
            text="DOUT PIN",
            font=("Arial", 15)).pack(pady=(20,5))
        Entry(
            self.master,
            textvariable=self.DOUT).pack()
        Label(
            self.master,
            text="SCK PIN",
            font=("Arial", 15)).pack(pady=(20,5))
        Entry(
            self.master,
            textvariable=self.SCK ).pack()
        Button(
            self.master,
            text="Siguiente",
            font=("Arial", 17),
            command= self.Print_MAC).pack()

    def ClearFrame(self):
        for widget in frame.winfo_children():
            widget.destroy()
            frame.pack_forget()

    def Print_MAC(self):
        ID = self.MAC+self.DOUT.get()+self.SCK.get()
        self.ClearFrame()
        #CODIGO NUEVO
        
        if self.SQL_Action.Select("tBasculas","*","ID_Bascula","'"+ID+"'") is None:
            self.SQL_Action.Insert("tBasculas",["ID_Bascula","Descripcion"],["'"+ID+"'","'Almacen'"])
        else:
            self.SQL_Action.Update("tBasculas","Descripcion = 'Almacen'","ID_Bascula","'"+ID+"'")
        #
        self.master.pack(side="top", expand=True, fill="both")
        Label(
            self.master,
            text= "BASCULA:",
            font=("Arial", 17)).pack()
        Label(
            self.master,
            text= ID,
            font=("Arial", 17),
            fg="#dba2fc").pack()

    def Calibration(self):
        try:
            GPIO.setmode(GPIO.BCM)  # set GPIO pin mode to BCM numbering
            # Create an object hx which represents your real hx711 chip
            # Required input parameters are only 'dout_pin' and 'pd_sck_pin'
            hx = HX711(dout_pin=int(self.DOUT.get()), pd_sck_pin=int(self.SCK.get()))
            # measure tare and save the value as offset for current channel
            # and gain selected. That means channel A and gain 128
            err = hx.zero()
            # check if successful
            if err:
                raise ValueError('Tare is unsuccessful.')

            reading = hx.get_raw_data_mean()
            if reading:  # always check if you get correct value or only False
                # now the value is close to 0
                Label(
                    self.master,
                    text= 'Data subtracted by offset but still not converted to units: ' + reading,
                    font=("Arial", 14)).pack()
            else:
                Label(
                    self.master,
                    text= 'invalid data ' + reading,
                    font=("Arial", 14)).pack()

            # In order to calculate the conversion ratio to some units, in my case I want grams,
            # you must have known weight.
            input('Put known weight on the scale and then press Enter')
            reading = hx.get_data_mean()
            if reading:
                print('Mean value from HX711 subtracted by offset:', reading)
                known_weight_grams = input(
                    'Write how many grams it was and press Enter: ')
                try:
                    value = float(known_weight_grams)
                    print(value, 'grams')
                except ValueError:
                    print('Expected integer or float and I have got:',
                          known_weight_grams)

                # set scale ratio for particular channel and gain which is
                # used to calculate the conversion to units. Required argument is only
                # scale ratio. Without arguments 'channel' and 'gain_A' it sets
                # the ratio for current channel and gain.
                ratio = reading / value  # calculate the ratio for channel A and gain 128
                hx.set_scale_ratio(ratio)  # set ratio for current channel
                print('Ratio is set.')
            else:
                raise ValueError('Cannot calculate mean value. Try debug mode. Variable reading:', reading)

            # Read data several times and return mean value
            # subtracted by offset and converted by scale ratio to
            # desired units. In my case in grams.
            print("Now, I will read data in infinite loop. To exit press 'CTRL + C'")
            input('Press Enter to begin reading')
            print('Current weight on the scale in grams is: ')
            while True:
                print(hx.get_weight_mean(20), 'g')
        except (KeyboardInterrupt, SystemExit):
            print('Bye :)')

        finally:
            GPIO.cleanup()

if __name__ == "__main__":
    root = Tk()
    root.title("Weighing System")
    # get screen width and height
    screen_width = root.winfo_screenwidth()
    screen_height = root.winfo_screenheight()
    # calculate position x and y coordinates
    x = (screen_width/2) - (400/2)
    y = (screen_height/2) - (300/2)
    root.geometry('%dx%d+%d+%d' % (400, 300, x, y))
    frame = Frame(root)
    frame.pack(side="top", expand=True, fill="both")
    app = App(frame)
    root.mainloop()