require 'zxing/decodable'
require 'rqrcode'

class QrcodeController < ActionController::Base
  # Prevent CSRF attacks by raising an exception.
  # For APIs, you may want to use :null_session instead.
  
  def show
  	render text: "Show"
  end

  def encode

  	result = { status: "failed" }
  	if (!params.has_key?(:message))
  		render json: result
  		return
  	end
  	qrcode = RQRCode::QRCode.new(params[:message])
  	
  	encodedqr = qrcode.as_png(
  		resize_gte_to: false,
  		resize_exactly_to: false,
  		fill: 'white',
  		color: 'black',
  		size: 120,
  		border_modules: 4,
  		module_px_size: 6,
  		file: nil
  		)
  	#IO.write("/tmp/github-qrcode.png", encodedqr)
  	encodedqr.save('tmp/generatedQR.png')
  	result = { status: "success", encoded: qrcode.to_s}
  	render json: result
  end

  def decode
  	result = { status: "failed" }
  	if (!params.has_key?(:filedata))
  		render json: result
  		return
  	end
 
  	uploadedFile = params[:filedata]
	decodedString = ZXing.decode uploadedFile
 	#decodedString = ZXing.decode 'Google Drive/testing QR/Screenshot 20116-05-28 21.10.37.png'
  	#file = File.open(params[:filedata].original_filename)
  	#render text: params[:filedata].original_filename
  	if !(decodedString.nil? || decodedString.empty?)
		result = { status: "success", decodedString: decodedString}
	end
  	render json: result
  end
end
