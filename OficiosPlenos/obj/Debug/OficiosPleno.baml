   M S B A M L   `   `   `  ����  OficiosPlenos     OficiosPlenos.OficiosPleno   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   p lTelerik.Windows.Controls.RibbonView, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7k gTelerik.Windows.Controls.Input, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7a ]Telerik.Windows.Data, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7e aTelerik.Windows.Controls, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7n	 jTelerik.Windows.Controls.GridView, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7p
 lTelerik.Windows.Controls.Navigation, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7Itelerik1http://schemas.telerik.com/2008/xaml/presentation     	 
 5   	   -   5          � Title$  Oficio enviado al Pleno��5   	   $	��239��5   	   $	��277��5   	    � Icon$ Resources/postal.png��5   	    � 
ResizeMode$ NoResize=�5
   	    � WindowStartupLocation$ CenterScreen=�5   	   .��5      � .+�5   
   �� $��	10,26,0,0q�6   $
��Left=�5      $	��Top=�5      $��Oficio:��5      �� 5   
   -   5         ��Name$ TxtOficioEnviado��5      $	��135��5      $��23��5      $��	59,26,0,0q�5      $
��Left=�5      $	��Top=�5       �� TextWrapping$
 Wrap=�5      ��5      �� *OficioPlenos+ �� Mode$ TwoWay=�5      �� 5   
   $��	10,71,0,0q�6   $
��Left=�5      $	��Top=�5      $��Fecha de envio:��5      ,  &Telerik.Windows.Controls.RadDatePicker  5    
   -   5          Name$ DpFechaEnvio��5        $	��146��5!       $��
48,102,0,0q�5"       $
��Left=�5#       $	��Top=�5$       0  *Telerik.Windows.Controls.RadDateTimePicker   SelectedValue 5%       �� *FEnvioOfPlenos+�� 5&   
   -   5        	 ��Name$	 BtnVeroficio��5&      $	��146��5'      $��
48,154,0,0q�5(      $
��Left=�5)      $	��Top=�5*      $��
Ver Oficio��5+      6&   �� 5,   
   -   5        $	 BtnGenerarOficio��5,      $	��146��5-      $��
48,154,0,0q�5.      $
��Left=�5/      $	��Top=�50      $��Generar Oficio��52      �� 54   
   -   5        $	 BtnCancelar��54      $��75��55      $��119,204,0,0q�56      $
��Left=�57      $	��Top=�58      $��Cancelar��5:      
 �� IsCancel
 . 5;      �� 5<   
   -   5        $	 
BtnGuardar��5<      $��75��5=      $��
39,204,0,0q�5>      $
��Left=�5?      $	��Top=�5@      $��Guardar��5B      5D      5E      