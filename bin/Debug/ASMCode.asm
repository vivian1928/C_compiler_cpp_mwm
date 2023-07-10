assume cs:codesg,ds:datasg
datasg segment
i dw 1 dup(?)
x dw 1 dup(?)
sum dd 1 dup(?)
a dd 1 dup(?)
b dd 1 dup(?)
datasg ends

codesg segment
start:
L1:mov ax,1
    mov x,ax
L2:mov ax,0
    mov sum,ax
L3:mov ax,10
    mov i,ax
L4:mov ax,i
    sub ax,0
L5:jna L15
L6:mov ax,i
    sub ax,2
L7:jna L11
L8:mov ax,sum
    add ax,3
    mov sum,ax
L10:jmp L13
L11:mov ax,sum
    add ax,4
    mov sum,ax
L13:mov ax,i
    sub ax,1
    mov i,ax
L14:jmp L4
L15:mov ax,x
    sub ax,1
L16:jne L18
L17:mov ax,1
    mov sum,ax
L18:mov ax,2
    mov sum,ax
L19:nop

    mov ax,4c00h
    int 21h
codesg ends
end start

